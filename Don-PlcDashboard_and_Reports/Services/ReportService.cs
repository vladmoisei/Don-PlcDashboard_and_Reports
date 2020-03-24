﻿using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Services
{
    public class ReportService
    {
        public bool IsReportSent { get; set; }
        public DateTime TimeOfReport { get; set; }
        public String MailList { get; set; }
        public string MailSubject { get; set; }
        public string MailBodyText { get; set; }
        public string MailFilePath { get; set; }
        public void SendDaillyReport(DateTime time)
        {
            MailSubject = "Raport stationari utilaje ajustaj";
            MailBodyText = string.Format("Buna dimineata. <br>Atasat gasiti raport stationari utilaje ajustaj <br>O zi buna.");

        }

        // Function make report and send mail if it is time
        public bool MakeReport(RaportareDbContext context)
        {
            if (IsReportTime(TimeOfReport))
            {
                if (!string.IsNullOrEmpty(MailList))
                {
                    TimeOfReport =ChangeDateKeepTime(TimeOfReport); // Add curent Date to Time Of report Variable, used to Save excel file for the previous day
                    MailSubject = "Raport stationari utilaje ajustaj";
                    MailBodyText = string.Format("Buna dimineata. <br>Atasat gasiti raport stationari utilaje ajustaj <br>O zi buna.");
                    MailFilePath = SaveExcelFileToDisk(TimeOfReport.AddDays(-1), TimeOfReport, context);
                    SendMail(MailList, MailFilePath, MailSubject, MailBodyText);
                    return true;
                }
            }
            return false;
        }
        public DateTime ChangeDateKeepTime(DateTime time)
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                time.Hour,
                time.Minute,
                time.Second);
        }
        // Function Check if TimeNow is biggger than the report set time
        public bool IsReportTime(DateTime time)
        {
            // IF report set time is < than current time make report and report set time plus 3 seconds is >= curent time stop make report (this way I make a window of 3 seconds to mke reports)
            if (TimeSpan.Compare(time.TimeOfDay, DateTime.Now.TimeOfDay) <= 0 && TimeSpan.Compare(time.AddSeconds(4).TimeOfDay, DateTime.Now.TimeOfDay) >= 0)
                return true;

            return false;
        }
        public void SendMail(string adreseMailDeTrimis, string filePathDeTrimis, string subiect, string bodyText)
        {
            try
            {
                // "don.rap.ajustaj@gmail.com", "v.moisei@beltrame-group.com, vladmoisei@yahoo.com"
                // Mail(emailFrom , emailTo)
                MailMessage mail = new MailMessage("don.rap.ajustaj@gmail.com", adreseMailDeTrimis);

                //mail.From = new MailAddress("don.rap.ajustaj@gmail.com");
                mail.Subject = subiect;
                string Body = bodyText;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                using (Attachment attachment = new Attachment(filePathDeTrimis))
                {
                    mail.Attachments.Add(attachment);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential("don.rap.ajustaj@gmail.com", "Beltrame.1");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    mail = null;
                    smtp = null;
                }

                // Console.WriteLine("Mail Sent succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * Functii creare folder si salvare fisiere exvcel cu consumul lunar
         */
        // Creare folder stocare fisiere consum gaz
        public string CreareFolderRaportare()
        {
            // Daca pui direct folderul de exp. Consum ... se salveaza in folderul radacina al proiectului
            string path = string.Format(@"c:\Stationari ajustaj service");
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    // Console.WriteLine("That path exists already.");
                    return path;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                // Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.Message);
                //MessageBox.Show(ex.Message);
                //throw ex;
            }

            return path;
        }

        // Functie verificare data cuprinse intre 2 date (format string) 
        public bool IsDateBetween(DateTime dataItem, DateTime dataFrom, DateTime dataTo)
        {
            if (dataItem.CompareTo(dataFrom) >= 0)
            {
                if (dataItem.CompareTo(dataTo) <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Query function Group By Single Property of object
        public IOrderedEnumerable<IGrouping<string, Defect>> GroupBySingleProperty(IEnumerable<Defect> listOfDefects)
        {
            Console.WriteLine("Group by a single property in an object:");

            // Variable queryLastNames is an IEnumerable<IGrouping<string, 
            // DataClass.Student>>. 
            var queryPlcModelNames =
                from defect in listOfDefects
                group defect by defect.PlcModel.Name into newGroup
                orderby newGroup.Key
                select newGroup;

            //foreach (var nameGroup in queryPlcModelNames)
            //{
            //    Console.WriteLine($"Key: {nameGroup.Key}");
            //    foreach (var defect in nameGroup)
            //    {
            //        Console.WriteLine($"\t{defect.PlcModel.Name}");
            //    }
            //}
            return queryPlcModelNames;
        }
        // Functie creare fisier excel cu consumul lunar
        // Functie exportare data to excel file and save to disk
        // returneaza FilePath
        public string SaveExcelFileToDisk(DateTime dataFrom, DateTime dataTo, RaportareDbContext _context)
        {
            List<Defect> listaDeAfisat = new List<Defect>(); // List to be writen in excel
            //return Content(dataFrom + "<==>" + dataTo);
            // Collect Data between given dates
            IEnumerable<Defect> listaSql = _context.Defects.Where(model => model.TimpStartDefect.CompareTo(dataFrom) >= 0 && model.TimpStartDefect.CompareTo(dataTo) <= 0);

            // Sort data by TimpStartDefect
            var listaExcel = listaSql.OrderBy(item => item.TimpStartDefect);

            // Create list to for excel file from data grouped by plc and sorted by TimpStartdefect
            foreach (var nameGroup in GroupBySingleProperty(listaExcel))
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var defect in nameGroup)
                {
                    Console.WriteLine($"\t{defect.PlcModel.Name}");
                    listaDeAfisat.Add(new Defect
                    {
                        PlcModel = defect.PlcModel,
                        TimpStartDefect = defect.TimpStartDefect,
                        TimpStopDefect = defect.TimpStopDefect,
                        MotivStationare = defect.MotivStationare,
                        IntervalStationare = defect.IntervalStationare
                    });
                }
            }

            // Create Excel file
            using (var pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Lista defecte");
                ws.Cells["A1:Z1"].Style.Font.Bold = true;

                ws.Cells["A1"].Value = "Denumire utilaj";
                ws.Cells["B1"].Value = "Timp Start Defect";
                ws.Cells["C1"].Value = "Timp Stop Defect";
                ws.Cells["D1"].Value = "Motiv Stationare";
                ws.Cells["E1"].Value = "Interval Stationare";

                int rowStart = 2;
                foreach (var elem in listaDeAfisat)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = elem.PlcModel.Name;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = elem.TimpStartDefect;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = elem.TimpStopDefect;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = elem.MotivStationare;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = elem.IntervalStationare;
                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                //Write the file to the disk
                string excelName = "RaportStationariAjustaj.xlsx";
                string filePath = string.Format("{0}/{1}", CreareFolderRaportare(), excelName);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
                //pck.Save();
                return filePath;
            }
        }
    }
}
