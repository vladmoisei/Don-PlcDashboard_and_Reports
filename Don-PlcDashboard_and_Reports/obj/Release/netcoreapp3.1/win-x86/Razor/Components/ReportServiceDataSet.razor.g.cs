#pragma checksum "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ReportServiceDataSet.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e50347078378f59f2f5b0c09171436101ad9825"
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
    public partial class ReportServiceDataSet : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Report Service Data Set</h3>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>Lista Mail raport: </p>\r\n");
            __builder.OpenElement(2, "input");
            __builder.AddAttribute(3, "class", "col-md-10");
            __builder.AddAttribute(4, "type", "text");
            __builder.AddAttribute(5, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 5 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ReportServiceDataSet.razor"
                                            raportService.MailList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => raportService.MailList = __value, raportService.MailList));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
            __builder.AddMarkupContent(8, "<p>Setare timp Raportare:</p>\r\n");
            __builder.OpenElement(9, "input");
            __builder.AddAttribute(10, "type", "time");
            __builder.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 7 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ReportServiceDataSet.razor"
                          raportService.TimeOfReport

#line default
#line hidden
#nullable disable
            , format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(12, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => raportService.TimeOfReport = __value, raportService.TimeOfReport, format: "HH:mm:ss", culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "class", "btn btn-primary");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ReportServiceDataSet.razor"
                                          SetOraAndMailReport

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(17, "Set data");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\ReportServiceDataSet.razor"
       
    string mailList;
    DateTime oraRaport;
    // Click Event Btn Set Hour And Mail Report
    public void SetOraAndMailReport()
    {
        Console.WriteLine(raportService.TimeOfReport.TimeOfDay.ToString());
        Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        Console.WriteLine("Is Report time: {0}", raportService.IsReportTime(raportService.TimeOfReport));
        Console.WriteLine(raportService.TimeOfReport.ToString());
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ReportService raportService { get; set; }
    }
}
#pragma warning restore 1591
