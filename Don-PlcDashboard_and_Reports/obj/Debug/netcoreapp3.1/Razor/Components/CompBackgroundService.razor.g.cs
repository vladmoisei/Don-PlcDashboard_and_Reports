#pragma checksum "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ff2fa4a645c95ba6c48fe31e8993b5fc68f643b"
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
    public partial class CompBackgroundService : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>BackgroundService</h2>\r\n\r\n");
            __builder.OpenElement(1, "section");
            __builder.AddAttribute(2, "id", "backgroundService");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.AddMarkupContent(4, "<div class=\"row\">\r\n    </div>\r\n        ");
            __builder.OpenElement(5, "h4");
            __builder.AddAttribute(6, "id", "ceas");
            __builder.AddContent(7, "Ceas: ");
            __builder.AddContent(8, 
#nullable restore
#line 8 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                             backgroundWorkService.LastTimeRunBackgroundWork.ToString("hh:mm:ss")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "h4");
            __builder.AddContent(11, " Service is Started: ");
            __builder.AddContent(12, 
#nullable restore
#line 9 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                  backgroundWork.IsRunnungBackgroundService

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n        ");
            __builder.OpenElement(14, "h4");
            __builder.AddContent(15, " Refresh Time Interval: ");
            __builder.OpenElement(16, "input");
            __builder.AddAttribute(17, "type", "number");
            __builder.AddAttribute(18, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                                                 backgroundWork.ReadingTimeInterval

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(19, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => backgroundWork.ReadingTimeInterval = __value, backgroundWork.ReadingTimeInterval, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "row");
            __builder.AddMarkupContent(23, "\r\n        ");
            __builder.OpenElement(24, "button");
            __builder.AddAttribute(25, "class", "col-md-6" + " btn" + " " + (
#nullable restore
#line 13 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                      backgroundWork.IsRunnungBackgroundService?"btn-success":"btn-outline-success"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 13 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                                                                                                                StartBackgroundService

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(27, "Start Backgorund Service");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n        ");
            __builder.OpenElement(29, "button");
            __builder.AddAttribute(30, "class", "col-md-6" + " btn" + " " + (
#nullable restore
#line 14 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                      !backgroundWork.IsRunnungBackgroundService?"btn-danger":"btn-outline-danger"

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
                                                                                                                               StopBackgroundService

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(32, "Stop Backgorund Service");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\CompBackgroundService.razor"
       
    BackgroundWorkService backgroundWorkService;
    protected override void OnInitialized()
    {
        backgroundWorkService = backgroundWork as BackgroundWorkService;
        RefreshUi();
    }

    // Click Event Start service
    public void StartBackgroundService()
    {
        backgroundWork.StartAsync(new System.Threading.CancellationToken(false));
    }

    // Click Event Start service
    public void StopBackgroundService()
    {
        backgroundWork.StopAsync(new System.Threading.CancellationToken());
    }

    // Refresh Ui
    void RefreshUi()
    {
        var timer = new Timer(new TimerCallback(_ =>
        {
            Console.WriteLine("Din timer");

            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }), null, 1000, 1000);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BackgroundWorkService backgroundWork { get; set; }
    }
}
#pragma warning restore 1591