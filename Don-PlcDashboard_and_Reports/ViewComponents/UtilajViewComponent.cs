using Don_PlcDashboard_and_Reports.Models;
using Don_PlcDashboard_and_Reports.Services;
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
        // Constructor: Inject PlcService To Get PLCViewModelList
        public UtilajViewComponent(PlcService plcService)
        {
            ListPlcViewModel = plcService.ListPlcViewModels;
        }
        // List Of Plc Model View
        public List<PlcViewModel> ListPlcViewModel;
        
        // Function Return PlcViewModel By Plc Name from the list
        public PlcViewModel GetPlcViewModelByName(string numePlc)
        {
            foreach (var plcViewModel in ListPlcViewModel)
            {
                if (plcViewModel.PlcModel.Name == numePlc)
                    return plcViewModel;
            }
            return new PlcViewModel(); // Or Return null
        }

        // Function called from View for each Plc 
        public async Task<IViewComponentResult> InvokeAsync(string numePlc)
        {
            ViewData["Nume"] = numePlc;
            @ViewData["chartId"] = "chartId"+numePlc;
            return View("Default", GetPlcViewModelByName(numePlc));
        }
    }
}
