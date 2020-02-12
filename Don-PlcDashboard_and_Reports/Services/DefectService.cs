using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using S7.Net;
using System;
using System.Collections.Generic;
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
        public void LogicBrackDowns(RaportareDbContext context, PlcModel plc)
        {
            // If is Breakdownin progress and list of defects is empty or last defect is finished
            if (IsBreakDownInProgress(plc)) {
                if (GetLastElementByPlc(context, plc) == null)
                    AddNewDefectForPlc(context, plc);
                else if (GetLastElementByPlc(context, plc).DefectFinalizat == true)
                    AddNewDefectForPlc(context, plc);
            }

        }

        // Add defect to DbContext for a given Plc (Start new defect)
        public void AddNewDefectForPlc(RaportareDbContext context, PlcModel plc)
        {
            context.Add(new Defect { 
                TimpStartDefect = DateTime.Now,
                DefectFinalizat = false ,
                PlcModelID = plc.PlcModelID 
            });
            context.SaveChanges();
        }

        // Get Last Element by Plc from context
        public Defect GetLastElementByPlc(RaportareDbContext context, PlcModel plc)
        {
            var defect = context.Defects.LastOrDefault(def => def.PlcModelID == plc.PlcModelID);
            if (defect != null) return defect;
            return null;
        }
        // Get Last not finished Defect from given Plc
        public Defect GetLastNotFinishedDefect(RaportareDbContext context, PlcModel plc)
        {
            // Get Last defect not finished defect of a Plc, from DbContext
            var defect = context.Defects.LastOrDefault(def => def.PlcModelID == plc.PlcModelID && def.TimpStopDefect == null);
            if (defect == null)
            {
                return null;
            }

            return defect;
        }

        // Is Last Added Defect Finished
        public bool IsLastDefectFinshed(RaportareDbContext context, PlcModel plc)
        {
            // Get Last defect not finished defect of a Plc, from DbContext
            var defect = context.Defects.Last();
            if (defect == null)
            {
                return false;
            }
            return (bool)defect.DefectFinalizat;
        }
        // Update last not finished Defect from given Plc to finished defect
        public void UpdateLastNotFinishedDefect(RaportareDbContext context, PlcModel plc)
        {
            // Get Last defect not finished defect of a Plc, from DbContext
            var defect = context.Defects.LastOrDefault(def => def.PlcModelID == plc.PlcModelID && def.TimpStopDefect == null);

            // Add MotivStationare, TimpStop Defect, interval Stationare and Defect finalizat
            defect.MotivStationare = GetMotivStationare(plc);
            defect.TimpStopDefect = DateTime.Now;
            defect.IntervalStationare = defect.TimpStopDefect - defect.TimpStartDefect;
            defect.DefectFinalizat = true;

            // Update Database
            context.Add(defect);
            context.SaveChanges();
        }

        // Get MotivStationare from Plc Tag
        public string GetMotivStationare(PlcModel plc)
        {
            // Check if plc is not connected and return messege Plc DEconectat
            try
            {
                if (!plc.PlcObject.IsConnected) return "Plc Deconectat";
            }
            catch (PlcException exPlc)
            {
                Console.WriteLine(String.Format("{0} <=> {1} <=> PlcaName: {2}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), exPlc.Message, plc.Name));
                return "Plc Deconectat";
            }

            // If Plc Connected return a type of breakdown messege
            if (Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "MechanicalBreakDown").Value))
                return "Defect mecanic";
            else if (Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "ElectricalBreakDown").Value))
                return "Defect electric";
            else if (Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "ProgrammedBreakDown").Value))
                return "Oprire programata";
            else if (Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "TechnologicalBreakDown").Value))
                return "Oprire tehnologica";
            else if (Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "NoCraneReadyBreakDown").Value))
                return "Lipsa pod rulant / Lipsa material";

            // If none of the predefined causes are not set return none was pressed
            return "Nu s-a apasat cauza"; ;
        }

        // Chek if brakdown is in progress
        public bool IsBreakDownInProgress(PlcModel plc)
        {
            return Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "BreakDownInProgress").Value);
        }

        // Chek if second brakdown is in progress
        public bool IsBreakDown2InProgress(PlcModel plc)
        {
            return Convert.ToBoolean(plc.TagsList.FirstOrDefault(tag => tag.Name == "BreakDown2InProgress").Value);
        }

    }
}
