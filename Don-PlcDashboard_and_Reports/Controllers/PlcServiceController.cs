using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Don_PlcDashboard_and_Reports.Controllers
{
    public class PlcServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}