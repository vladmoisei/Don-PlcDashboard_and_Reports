using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.ViewComponents
{
    [ViewComponent(Name = "UtilajViewComponent")]
    public class UtilajViewComponent : ViewComponent
    {

        public string NumePlc { get; set; }
        public string TextAfisare { get; set; }
        public string MotivStationare { get; set; }
        public DateTime TimpStartDefect { get; set; }
        public DateTime TimpStopDefect { get; set; }
        public double RandamentActual { get; set; }
        public double RandamentRealizat { get; set; }
        public bool IsConnected { get; set; }
        public TimeSpan ScanTime { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(string numePlc)
        {
            ViewData["Nume"] = numePlc;
            return View("Default");
        }
    }
}
