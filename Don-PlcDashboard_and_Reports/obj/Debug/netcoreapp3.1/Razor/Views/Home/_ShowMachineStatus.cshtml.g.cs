#pragma checksum "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\_ShowMachineStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ce210f150914b51c83d4d4d4bd3009e6f4fd7ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__ShowMachineStatus), @"mvc.1.0.view", @"/Views/Home/_ShowMachineStatus.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ce210f150914b51c83d4d4d4bd3009e6f4fd7ba", @"/Views/Home/_ShowMachineStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9097f515af37687985e744e1327ba3d8dd9b7c7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__ShowMachineStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Don_PlcDashboard_and_Reports.Models.PlcViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/charJs/Chart.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ce210f150914b51c83d4d4d4bd3009e6f4fd7ba3804", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1 class=\"display-4\">\r\n    Dashboard\r\n</h1>\r\n\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\_ShowMachineStatus.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-3 plcModelView_border\">\r\n            <div style=\"width:100%\">\r\n                ");
#nullable restore
#line 15 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\_ShowMachineStatus.cshtml"
           Write(await Component.InvokeAsync("UtilajViewComponent", new { numePlc = item.PlcModel.Name }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 18 "C:\Users\User\Desktop\Programe cod sursa\Don-Dashboard_Stationari_Ajustaj\Don-PlcDashboard_and_Reports\Don-PlcDashboard_and_Reports\Views\Home\_ShowMachineStatus.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Don_PlcDashboard_and_Reports.Models.PlcViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
