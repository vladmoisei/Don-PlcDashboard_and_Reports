#pragma checksum "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ComponentProba.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "047996aecd585b83cf0defbcecf449b4554d7dc8"
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
    public partial class ComponentProba : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 11 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ComponentProba.razor"
       
    public string Name { get; set; } = "Jon";

    public string TimeRendered;
    protected override void OnInitialized()
    {
        TimeRendered = DateTime.Now.ToString("hh:mm:ss:ms");
    }

    public void Toggle()
    {
        if (Name == "Jon")
        {
            Name = "Susan";
        }
        else
        {
            Name = "Jon";
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
