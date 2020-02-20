using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Don_PlcDashboard_and_Reports.Models;
using Don_PlcDashboard_and_Reports.ViewComponents;
using Don_PlcDashboard_and_Reports.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Don_PlcDashboard_and_Reports.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TimedService _backgroundService;
        PlcService _plcService;
        public HomeController(ILogger<HomeController> logger, TimedService backGroundService, StartAutBackgroundService bk, PlcService plcService)
        {
            _logger = logger;
            _backgroundService = backGroundService;
            _plcService = plcService;
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-A CREAT HOMECONTROLLER AR TREBUI SA URMEZE SI BACKGROUND SERVICE");
            _logger.LogInformation("{LasttimeScan} {text}", _backgroundService.LastTimeRunBackgroundWork.ToString("dd.MM.yyyy hh:mm:ss"), "Timp din backgroundService in HomeController");
        }

        public IActionResult Index()
        {
            return View();
            //return ViewComponent("UtilajViewComponent");
        }

        // Return Partial View Dasboard List with PlcViewModel
        public async Task<IActionResult> _ShowMachineStatus()
        {
            return PartialView(_plcService.ListPlcViewModels);
        }
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
