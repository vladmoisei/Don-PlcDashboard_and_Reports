using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Models
{
    public class PlcViewModel
    {
        public string NumePlcAfisat { get; set; }
        public PlcModel PlcModel { get; set; }
        public string TextAfisare { get; set; }
        public string MotivStationare { get; set; }
        public DateTime TimpStartDefect { get; set; }
        public DateTime TimpStopDefect { get; set; }
        public bool IsDefectFinalizat { get; set; }
        public double RandamentActual { get; set; }
        public double RandamentRealizat { get; set; }
        public bool IsConnected { get; set; }
        public TimeSpan ScanTime { get; set; }

        // Map Defect To PlcViewModel
        public void MapDefect(Defect defect, PlcModel plc)
        {
            IsConnected = plc.PlcObject.IsConnected;
            if (defect == null) return;
            MotivStationare = defect.MotivStationare;
            TimpStartDefect = defect.TimpStartDefect;
            TimpStopDefect = defect.TimpStopDefect;
            IsDefectFinalizat = defect.DefectFinalizat;
            NumePlcAfisat = GetNumePlcAfisat(defect);
            TextAfisare = GetTextAfisare();

        }
        // Must Run after MapDefect()
        public string GetTextAfisare()
        {
            if (IsDefectFinalizat)
            {
                TimeSpan interval = DateTime.Now - TimpStopDefect;
                if (interval.TotalHours >= 1)
                    return "Functioneaza de " + interval.TotalHours.ToString("f1") + " ore";

                return "Functioneaza de " + interval.TotalMinutes.ToString("f0") + " min";
            }
            else
            {
                TimeSpan interval = DateTime.Now - TimpStartDefect;
                if (interval.TotalHours >= 1)
                    return MotivStationare + " de " + interval.TotalHours.ToString("f1") + " ore";
                return MotivStationare + " de " + interval.TotalMinutes.ToString("f0") + " min";
            }
        }

        public string GetNumePlcAfisat(Defect defect)
        {
            // Set Nume PLC Afisat by PlcModel.Name
            switch (defect.PlcModel.Name)
            {
                case "RullatriceVeche":
                    return "Rullatrice ProjectMan";
                case "RullatriceLandgraf":
                    return "Rullatrice Langraf";
                case "Elind":
                    return "Elind";
                case "PelatriceLandgraf":
                    return "Pelatrice Landgraf";
                case "PresaValdora":
                    return "Presa Valdora";
                default:
                    return "";
            }
        }
    }
}
