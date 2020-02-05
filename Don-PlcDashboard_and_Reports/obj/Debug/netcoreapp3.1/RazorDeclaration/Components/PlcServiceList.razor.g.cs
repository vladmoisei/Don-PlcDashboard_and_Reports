#pragma checksum "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02612156e059270b81cec5e747a3f0b523f5fb90"
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
#line 1 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.Extensions.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using S7.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class PlcServiceList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 96 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
       
    // plcServiceList from PlcServicePlcList
    public List<PlcModel> plcServiceList;
    // Selcted Plc
    public PlcModel selectedPlc;
    // Initialize List of Plc from DbContext Plc
    protected override void OnInitialized()
    {
        selectedPlc = new PlcModel { Name = "None", TagsList = new List<TagModel>() };
        plcServiceList = plcService.ListPlcs;
        RefreshUi();
    }
    // Click event create plc list
    private async Task CretePlcList()
    {
        await plcService.InitializeListOfPlcAsync(context);
    }

    // Click event Connect all Plcs
    private void ConnectAllPlcs()
    {
        foreach (var plc in plcService.ListPlcs)
        {
            plcService.ConnectPlc(plc.PlcObject);
        }
    }
    // Click event Disconnect all Plcs
    private void DisconnectAllPlcs()
    {
        foreach (var plc in plcService.ListPlcs)
        {
            plcService.DisconnectPlc(plc.PlcObject);
        }
    }

    // For refrehing UI
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RaportareDbContext context { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PlcService plcService { get; set; }
    }
}
#pragma warning restore 1591
