#pragma checksum "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3217b35ca5a6b1d8a206ad0503b9356a5dd9ccba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\_ViewImports.cshtml"
using Don_PlcDashboard_and_Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\_ViewImports.cshtml"
using Don_PlcDashboard_and_Reports.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3217b35ca5a6b1d8a206ad0503b9356a5dd9ccba", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9097f515af37687985e744e1327ba3d8dd9b7c7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("    <div id=\"dashboard\"></div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"    <script>
        // Add Class Container Fluid To Index page (to see more PLCs on the same page)
        var container = document.getElementById(""container"");
        container.classList.remove(""container"");
        container.classList.add(""container-fluid"");
        // Creare element lista selectie afisare date
        //let selectieAfisareDateElement = document.getElementById(""dashboard"");
        function autoRefreshPage() {
            //window.location = window.location.href;
            $.ajax({
                url: "" /Home/_ShowMachineStatus"",
                type: 'GET',
                //data: {
                //    numePlc: this.value
                //},
                success: function (response) {
                    console.log("" RAspuns: success"");
                    //console.log(""Id: "" + response.id);
                    //console.log(""Data PReluare: "" + response.data);
                    //console.log(checkWithValue(response.id));
                    $(""#dashboard""");
                WriteLiteral(@").html(response);
                    //chengeCheckBoxWithData(response.id, response.data);
                },
                error: function (response) {
                    console.log(""Raspuns din erorr: error"");
                }

            });
            console.log(""Refresh page"");
        }
        setInterval('autoRefreshPage()', 10000); // Resetare la 6 secunde


    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
