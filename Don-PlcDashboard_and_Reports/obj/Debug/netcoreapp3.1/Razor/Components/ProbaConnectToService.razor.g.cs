#pragma checksum "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5733dfcc0fd12229a12c3baccb2ecfa544c44d72"
// <auto-generated/>
#pragma warning disable 1591
namespace Don_PlcDashboard_and_Reports.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Don_PlcDashboard_and_Reports.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using Microsoft.Extensions.Hosting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using S7.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
    public partial class ProbaConnectToService : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>ProbaConnectToService</h3>\r\n\r\nHello ");
            __builder.AddContent(1, 
#nullable restore
#line 6 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
       Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(2, "\r\nId: ");
            __builder.AddContent(3, 
#nullable restore
#line 7 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
     Id

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.AddMarkupContent(5, "<a class=\"btn btn-dark\" href=\"/Plcs\">Proba ancor link</a>\r\n");
            __builder.AddMarkupContent(6, "<a asp-action=\"Delete\" asp-route-id=\"2\">Delete</a>\r\n\r\n");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
                  Toggle

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(9, "Toggle button");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
            __builder.OpenElement(11, "button");
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
                  GetValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(13, "Get Service Valoare");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
                  IncreaseValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Increase Service Valoare by 10");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\nValoare: ");
            __builder.AddContent(19, 
#nullable restore
#line 15 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
          Valoare

#line default
#line hidden
#nullable disable
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ProbaConnectToService.razor"
       
    [Parameter]
    public int Id { get; set; }

    public string Name { get; set; } = "Jon";
    public int Valoare { get; set; }


    public void Toggle()
    {
        if (Name == "Jon")
        {
            Name = "Susan";
        }
        else
        {
            Name = plcService.ClickTestare();
        }
    }

    public void GetValue()
    {
        Valoare = plcService.Valoare;
    }

    public void IncreaseValue()
    {
        plcService.Valoare += 10;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PlcService plcService { get; set; }
    }
}
#pragma warning restore 1591
