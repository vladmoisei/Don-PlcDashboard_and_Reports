#pragma checksum "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4ddb3a7f8ce69b613e792e5ec393f8903fe9294"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Don_PlcDashboard_and_Reports.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.Extensions.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using S7.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class CompBackgroundService : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
       
    TimedService backgroundWorkService;
    protected override void OnInitialized()
    {
        backgroundWorkService = backgroundWork as TimedService;
        RefreshUi();
    }

    // Click Event Start Background service
    public void StartBackgroundService()
    {
        backgroundWork.StartAsync(new System.Threading.CancellationToken(false));
    }

    // Click Event Stop Background service
    public void StopBackgroundService()
    {
        backgroundWork.StopAsync(new System.Threading.CancellationToken());
    }

    // Click Event Start Defect service
    public void StartDefectService()
    {
        defectService.IsAvailableDefectService = true;
    }

    // Click Event Stop Defect service
    public void StopDefectService()
    {
        defectService.IsAvailableDefectService = false;
    }

    // Refresh Ui
    void RefreshUi()
    {
        var timer = new Timer(new TimerCallback(_ =>
        {
            //Console.WriteLine("Din timer");

            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }), null, 1000, 1000);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DefectService defectService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private TimedService backgroundWork { get; set; }
    }
}
#pragma warning restore 1591
