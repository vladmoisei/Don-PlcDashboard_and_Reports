#pragma checksum "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e30a69e5b59b346e9f0c9f79c7317ae0293db055"
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
    public partial class PlcServiceList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>PlcServiceList</h3>\r\n\r\n");
            __builder.AddMarkupContent(1, "<h1>Index</h1>\r\n\r\n");
            __builder.OpenElement(2, "p");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "btn btn-primary");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                              CretePlcList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(7, "Create Plc List");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "btn btn-danger");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 9 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                             (() => plcService.ListPlcs.Clear())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(12, "Clear Plc List");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n");
            __builder.OpenElement(15, "table");
            __builder.AddAttribute(16, "class", "table");
            __builder.AddMarkupContent(17, "\r\n    ");
            __builder.OpenElement(18, "thead");
            __builder.AddMarkupContent(19, "\r\n        ");
            __builder.OpenElement(20, "tr");
            __builder.AddMarkupContent(21, "\r\n            <th></th>\r\n            ");
            __builder.AddMarkupContent(22, "<th>\r\n                Nume\r\n            </th>\r\n            ");
            __builder.AddMarkupContent(23, "<th>\r\n                Ip\r\n            </th>\r\n            ");
            __builder.AddMarkupContent(24, "<th>\r\n                IsConnected\r\n            </th>\r\n            ");
            __builder.OpenElement(25, "th");
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "class", "btn btn-primary");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                                          ConnectAllPlcs

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(30, "Connect All");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n            ");
            __builder.OpenElement(33, "th");
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "button");
            __builder.AddAttribute(36, "class", "btn btn-danger");
            __builder.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                                         DisconnectAllPlcs

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(38, "Disconnect All");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.OpenElement(43, "tbody");
            __builder.AddMarkupContent(44, "\r\n");
#nullable restore
#line 33 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
         foreach (var plc in plcServiceList)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(45, "            ");
            __builder.OpenElement(46, "tr");
            __builder.AddMarkupContent(47, "\r\n                ");
            __builder.OpenElement(48, "td");
            __builder.AddMarkupContent(49, "\r\n                    ");
            __builder.OpenElement(50, "button");
            __builder.AddAttribute(51, "class", "btn btn-outline-primary");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                                                      (() => selectedPlc=plc)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(53, "TagsList");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                ");
            __builder.OpenElement(56, "td");
            __builder.AddMarkupContent(57, "\r\n                    ");
            __builder.AddContent(58, 
#nullable restore
#line 40 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     plc.Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(59, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n                ");
            __builder.OpenElement(61, "td");
            __builder.AddMarkupContent(62, "\r\n                    ");
            __builder.AddContent(63, 
#nullable restore
#line 43 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     plc.Ip

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n                ");
            __builder.OpenElement(66, "td");
            __builder.AddMarkupContent(67, "\r\n                    ");
            __builder.AddContent(68, 
#nullable restore
#line 46 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     plc.PlcObject.IsConnected

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(69, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n                ");
            __builder.OpenElement(71, "td");
            __builder.AddMarkupContent(72, "\r\n                    ");
            __builder.OpenElement(73, "button");
            __builder.AddAttribute(74, "class", "btn btn-outline-primary");
            __builder.AddAttribute(75, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 49 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                                                      (() => plcService.ConnectPlc(plc.PlcObject))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(76, "Connect Plc");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n                ");
            __builder.OpenElement(79, "td");
            __builder.AddMarkupContent(80, "\r\n                    ");
            __builder.OpenElement(81, "button");
            __builder.AddAttribute(82, "class", "btn btn-outline-danger");
            __builder.AddAttribute(83, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                                                                     (() => plcService.DisconnectPlc(plc.PlcObject))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(84, "Disconnect Plc");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n");
#nullable restore
#line 55 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(88, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\r\n\r\n");
            __builder.OpenElement(91, "h3");
            __builder.AddContent(92, "Tag List for ");
            __builder.AddContent(93, 
#nullable restore
#line 59 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                  selectedPlc.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n");
            __builder.OpenElement(95, "table");
            __builder.AddAttribute(96, "class", "table");
            __builder.AddMarkupContent(97, "\r\n    ");
            __builder.AddMarkupContent(98, @"<thead>
        <tr>
            <th>
                Name
            </th>
            <th>
                Adress
            </th>
            <th>
                DataType
            </th>
            <th>
                Value
            </th>
        </tr>
    </thead>
    ");
            __builder.OpenElement(99, "tbody");
            __builder.AddMarkupContent(100, "\r\n");
#nullable restore
#line 78 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
         foreach (var tag in selectedPlc.TagsList)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(101, "            ");
            __builder.OpenElement(102, "tr");
            __builder.AddMarkupContent(103, "\r\n                ");
            __builder.OpenElement(104, "td");
            __builder.AddMarkupContent(105, "\r\n                    ");
            __builder.AddContent(106, 
#nullable restore
#line 82 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     tag.Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(107, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n                ");
            __builder.OpenElement(109, "td");
            __builder.AddMarkupContent(110, "\r\n                    ");
            __builder.AddContent(111, 
#nullable restore
#line 85 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     tag.Adress

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(112, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\r\n                ");
            __builder.OpenElement(114, "td");
            __builder.AddMarkupContent(115, "\r\n                    ");
            __builder.AddContent(116, 
#nullable restore
#line 88 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     tag.DataType

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(117, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(118, "\r\n                ");
            __builder.OpenElement(119, "td");
            __builder.AddMarkupContent(120, "\r\n                    ");
            __builder.AddContent(121, 
#nullable restore
#line 91 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
                     tag.Value

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(122, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(124, "\r\n");
#nullable restore
#line 94 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(125, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 98 "C:\Users\IA\source\repos\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Components\PlcServiceList.razor"
       
    // plcServiceList from PlcServicePlcList
    public List<PlcModel> plcServiceList;
    // Selcted Plc
    public PlcModel selectedPlc;
    // Initialize List of Plc from DbContext Plc
    protected override void OnInitialized()
    {
        selectedPlc = new PlcModel { Name = "None", TagsList = new List<TagModel>() };
        plcServiceList = plcService.ListPlcs;
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

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RaportareDbContext context { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PlcService plcService { get; set; }
    }
}
#pragma warning restore 1591
