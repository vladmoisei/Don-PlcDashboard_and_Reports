using Don_PlcDashboard_and_Reports.Services;
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
        public string RandamentActual { get; set; }
        public string RandamentRealizat { get; set; }
        public bool IsConnected { get; set; }
        public TimeSpan ScanTime { get; set; }
        public int[] ChartDefectsInPercent { get; set; }


        // Map Defect To PlcViewModel
        public void MapDefect(PlcService plcService,Defect defect, PlcModel plc, List<Defect> defects)
        {
            IsConnected = plcService.IsAvailableIpAdress(plc);
            if (defect == null) return;
            MotivStationare = defect.MotivStationare;
            TimpStartDefect = defect.TimpStartDefect;
            TimpStopDefect = defect.TimpStopDefect;
            IsDefectFinalizat = defect.DefectFinalizat;
            NumePlcAfisat = GetNumePlcAfisat(defect);
            TextAfisare = GetTextAfisare();
            ChartDefectsInPercent = GetItemSourceGraficDefects(defects);
            RandamentRealizat = GetRandamentRealizat(defects);
        }
        // Get Randament Total
        public string GetRandamentRealizat(List<Defect> listaDefecte)
        {
            if (listaDefecte.Count > 0)
            {
                // Declar variabile calcul
                TimeSpan interval = DateTime.Now - listaDefecte.FirstOrDefault().TimpStartDefect;
                double maxHoursFunctionare = 24;
                double totalHoursStationare = 0.0;
                double totalHoursFunctionare = 0.0;
                double totalHoursOprireProgramata = 0.0;
                double randamentActual = 0.0;

                maxHoursFunctionare = interval.TotalHours;
                // Calcul randament
                foreach (Defect defect in listaDefecte)
                {
                    if (defect.MotivStationare == "Oprire programata")
                        totalHoursOprireProgramata += defect.IntervalStationare.TotalHours;
                    else totalHoursStationare += defect.IntervalStationare.TotalHours;
                }

                maxHoursFunctionare -= totalHoursOprireProgramata;
                totalHoursFunctionare = maxHoursFunctionare - totalHoursStationare;
                randamentActual = (totalHoursFunctionare / maxHoursFunctionare) * 100;
                
                return "R. Realizat: " + randamentActual.ToString("f0") + "%";
            }
            return "R. Realizat: 100%";
        }
        // Get Item Source Grafic Stationari TO DO
        public int[] GetItemSourceGraficDefects(List<Defect> listaDefecte)
        {
            double timpTotalDefectMecanic = 0;
            double timpTotalDefectElectric = 0;
            double timpTotalOprireProgramata = 0;
            double timpTotalOprireTehnologica = 0;
            double timpTotalLipsaMaterialPod = 0;
            double timpTotalNuS_aApasatCauza = 0;
            double timpTotalStationari = 0;

            // Calculam timp in ore pentru fiecare motiv stationare si total stationare in ore
            foreach (Defect defect in listaDefecte)
            {
                timpTotalStationari += defect.IntervalStationare.TotalHours;
                switch (defect.MotivStationare)
                {
                    case "Defect mecanic":
                        timpTotalDefectMecanic += defect.IntervalStationare.TotalHours;
                        break;
                    case "Defect electric":
                        timpTotalDefectElectric += defect.IntervalStationare.TotalHours;
                        break;
                    case "Oprire programata":
                        timpTotalOprireProgramata += defect.IntervalStationare.TotalHours;
                        break;
                    case "Oprire tehnologica":
                        timpTotalOprireTehnologica += defect.IntervalStationare.TotalHours;
                        break;
                    case "Lipsa pod rulant / Lipsa material":
                        timpTotalLipsaMaterialPod += defect.IntervalStationare.TotalHours;
                        break;
                    case "Nu s-a apasat cauza":
                        timpTotalNuS_aApasatCauza += defect.IntervalStationare.TotalHours;
                        break;
                    default:
                        break;
                }
            }

            // Calculate procent
            int procentDefectMecanic = (int)Math.Round(timpTotalDefectMecanic / timpTotalStationari * 100);
            int procentDefectElectric = (int)Math.Round(timpTotalDefectElectric / timpTotalStationari * 100);
            int procentOprireProgramata = (int)Math.Round(timpTotalOprireProgramata / timpTotalStationari * 100);
            int procentOprireTehnologica = (int)Math.Round(timpTotalOprireTehnologica / timpTotalStationari * 100);
            int procentLipsaMaterialPod = (int)Math.Round(timpTotalLipsaMaterialPod / timpTotalStationari * 100);
            int procentNuS_aApasatCauza = (int)Math.Round(timpTotalNuS_aApasatCauza / timpTotalStationari * 100);

            return new int[]
               {
                    procentDefectMecanic,
                    procentDefectElectric,
                    procentOprireProgramata,
                    procentOprireTehnologica,
                    procentLipsaMaterialPod,
                    procentNuS_aApasatCauza
               };
        }
        // Must Run after MapDefect()
        public string GetTextAfisare()
        {
            if (IsDefectFinalizat)
            {
                TimeSpan interval = LimitMaxTimeSpan(TimpStopDefect, DateTime.Now);
                if (interval.TotalHours >= 1)
                    return "Functioneaza de " + interval.TotalHours.ToString("f1") + " ore";

                return "Functioneaza de " + interval.TotalMinutes.ToString("f0") + " min";
            }
            else
            {
                TimeSpan interval = LimitMaxTimeSpan(TimpStartDefect, DateTime.Now);
                if (interval.TotalHours >= 1)
                    return MotivStationare + " de " + interval.TotalHours.ToString("f1") + " ore";
                return MotivStationare + " de " + interval.TotalMinutes.ToString("f0") + " min";
            }
        }

        // Function Limit Max TimeSpan, don't pass maximum range
        public TimeSpan LimitMaxTimeSpan(DateTime timpStart, DateTime timpStop)
        {
            try
            {
                if ((timpStop - timpStart) >= TimeSpan.MaxValue)
                    return TimeSpan.MaxValue;
                return timpStop - timpStart;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(String.Format("{0} <=> {1}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message));
                return TimeSpan.MaxValue;
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
