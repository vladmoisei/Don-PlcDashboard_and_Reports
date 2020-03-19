using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Services
{
    public class DefectService
    {
        public bool IsAvailableDefectService { get; set; }

        // Logic IfBrackDownInProgrss Add Defect, Update It, Add Second Defect
        public void LogicBrackDowns(RaportareDbContext context, PlcModel plc, PlcService plcService, ReportService reportService)
        {
            Defect lastDefect = GetLastElementByPlc(context, plc); // Get Last defect from Plc

            // If is time of report finalise last defect and send mail (added for report excel file)
            if (lastDefect != null && lastDefect.DefectFinalizat == false)
            { //if list is not empty and last defect is not finalised
                // make report if it is time TODO
                if (reportService.MakeReport(context)) // make report to excel
                    UpdateLastNotFinishedDefect(context, lastDefect); // finished not finalised defect
            }
            // Add PlcViewModel
            foreach (var plcViewModel in plcService.ListPlcViewModels)
            {
                if (lastDefect != null)
                    if (plcViewModel.PlcModel.Name == plc.Name)
                    {
                        plcViewModel.MapDefect(plcService, lastDefect, plc, context.Defects.Where(def => def.PlcModelID == plc.PlcModelID).ToList());
                        break;
                    }
            }

            // If is Breakdown in progress and list of defects is empty or last defect is finished Add Defect to list
            if (IsBreakDownInProgress(plc))
            { // if is brackdown
                if (lastDefect == null) // if list is empty
                    AddNewDefectForPlc(context, plc); // Add Defect
                else if (lastDefect.DefectFinalizat == true) // if list is not empty and last defect is finalised
                    AddNewDefectForPlc(context, plc); // Add defect
                else if (lastDefect.DefectFinalizat == false) // if last defect is not finalised add Motiv Stationare
                {
                    lastDefect.MotivStationare = GetMotivStationare(plcService, plc); // Add Motiv Stationare to lastDefect when it is pressed the button
                    lastDefect.TimpStopDefect = DateTime.Now;  // Add Stop time defect dynamic
                    // Catch overflow error to IntervalStationare
                    try
                    {
                        lastDefect.IntervalStationare = LimitMaxTimeSpan(lastDefect.TimpStartDefect, lastDefect.TimpStopDefect);// Add dynamic interval stationare
                        // Limit the Interval Stationare Max Value
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, lastDefect.PlcModel.Name));
                        lastDefect.IntervalStationare = TimeSpan.MaxValue;
                    }

                    context.Update(lastDefect); // Update DbContext with motiv stationare
                }
            }
            else // when machine start work again finished defect
            {
                if (lastDefect != null && lastDefect.DefectFinalizat == false) //if list is not empty and last defect is not finalised
                    UpdateLastNotFinishedDefect(context, lastDefect); // finished not finalised defect
            }
        }

        // Add defect to DbContext for a given Plc (Start new defect)
        public void AddNewDefectForPlc(RaportareDbContext context, PlcModel plc)
        {
            context.Add(new Defect
            {
                TimpStartDefect = DateTime.Now,
                DefectFinalizat = false,
                PlcModelID = plc.PlcModelID,
                TimpStopDefect = DateTime.Now,
                IntervalStationare = new TimeSpan(),
                MotivStationare = "Start Defect"
            });
            context.SaveChanges();
        }

        // Get Last Element by Plc from context
        public Defect GetLastElementByPlc(RaportareDbContext context, PlcModel plc)
        {
            Defect defect = null;
            try
            {
                defect = context.Defects.Include(t => t.PlcModel).Where(def => def.PlcModelID == plc.PlcModelID).ToList().Last();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(String.Format("{0} <=> {1} <=> Din GetLast Element By PlcName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.Name));
                return null;
            }

            if (defect != null) return defect;
            return null;
        }
        // Get Last not finished Defect from given Plc
        public Defect GetLastNotFinishedDefect(RaportareDbContext context, PlcModel plc)
        {
            Defect defect = null;
            try
            {
                defect = context.Defects.Where(def => def.PlcModelID == plc.PlcModelID && def.DefectFinalizat == false).ToList().Last();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.Name));
                return null;
            }
            // Get Last defect not finished defect of a Plc, from DbContext

            return defect;
        }

        // Is Last Added Defect Finished
        public bool IsLastDefectFinshed(RaportareDbContext context, PlcModel plc)
        {
            Defect defect = null;
            try
            {
                // Get Last defect not finished defect of a Plc, from DbContext
                defect = context.Defects.Where(p => p.PlcModelID == plc.PlcModelID).Last();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.Name));
                return false;
            }

            return defect.DefectFinalizat;
        }

        // Function Limit Max TimeSpan, don't pass maximum range
        public TimeSpan LimitMaxTimeSpan(DateTime timpStart, DateTime timpStop)
        {
            if ((timpStop - timpStart) >= TimeSpan.MaxValue)
                return TimeSpan.MaxValue;
            return timpStop - timpStart;
        }
        // Update last not finished Defect from given Plc to finished defect
        public void UpdateLastNotFinishedDefect(RaportareDbContext context, Defect defect)
        {
            // Add MotivStationare, TimpStop Defect, interval Stationare and Defect finalizat
            defect.TimpStopDefect = DateTime.Now;
            // Catch overflow error to IntervalStationare
            try
            {
                // Limit the Interval Stationare Max Value
                defect.IntervalStationare = LimitMaxTimeSpan(defect.TimpStartDefect, defect.TimpStopDefect);
            }
            catch (OverflowException ex)
            {
                defect.IntervalStationare = TimeSpan.MaxValue;
                Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, defect.PlcModel.Name));
            }

            defect.DefectFinalizat = true;
            // Update Database
            context.Update(defect);
            context.SaveChanges();
        }

        // Get MotivStationare from Plc Tag
        public string GetMotivStationare(PlcService plcService, PlcModel plc)
        {
            // Check if plc is not connected and return messege Plc DEconectat
            try
            {
                if (!plcService.IsAvailableIpAdress(plc)) return "Plc Deconectat";
            }
            catch (PlcException exPlc)
            {
                Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), exPlc.Message, plc.Name));
                return "Plc Deconectat";
            }

            // If Plc Connected return a type of breakdown messege
            if (Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "MechanicalBreakDown").ToList().FirstOrDefault().Value))
                return "Defect mecanic";
            else if (Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "ElectricalBreakDown").ToList().FirstOrDefault().Value))
                return "Defect electric";
            else if (Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "ProgrammedBreakDown").ToList().FirstOrDefault().Value))
                return "Oprire programata";
            else if (Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "TechnologicalBreakDown").ToList().FirstOrDefault().Value))
                return "Oprire tehnologica";
            else if (Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "NoCraneReadyBreakDown").ToList().FirstOrDefault().Value))
                return "Lipsa pod rulant / Lipsa material";

            // If none of the predefined causes are not set return none was pressed
            return "Nu s-a apasat cauza";
        }

        // Chek if brakdown is in progress
        public bool IsBreakDownInProgress(PlcModel plc)
        {
            return Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "BreakDownInProgress").ToList().FirstOrDefault().Value);
        }

        // Chek if second brakdown is in progress
        public bool IsBreakDown2InProgress(PlcModel plc)
        {
            return Convert.ToBoolean(plc.TagsList.Where(tag => tag.Name == "BreakDown2InProgress").ToList().FirstOrDefault().Value);
        }

        // Added logic to import Data From Csv Files
        // Methods to read csv file and import return list of defects

        // Functie convertire din string in dateTime format
        public DateTime GetDateTimeFromString(string dateToParse)
        {

            DateTime parsedDate = DateTime.ParseExact(dateToParse,
                                                      "dd/MM/yyyy HH:mm",
                                                      CultureInfo.InvariantCulture);
            return parsedDate;
        }

        // Functie convertire din string in timespan format
        public TimeSpan GetTimeSpanFromString(string dateToParse)
        {

            TimeSpan parsedDate = TimeSpan.Parse(dateToParse);
            return parsedDate;
        }

        // Functie Get Defect Values From CSV File
        public List<Defect> GetListOfDefectsFromFileCSV(IFormFile file, int plcModelId)
        {
            List<Defect> listaDefecte = new List<Defect>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');

                    listaDefecte.Add(new Defect
                    {
                        TimpStartDefect = GetDateTimeFromString(values[1]),
                        DefectFinalizat = true,
                        PlcModelID = plcModelId,
                        TimpStopDefect = GetDateTimeFromString(values[2]),
                        IntervalStationare = GetTimeSpanFromString(values[4]),
                        MotivStationare = values[3]
                    });
                }
            }

            return listaDefecte;
        }
    }
}
