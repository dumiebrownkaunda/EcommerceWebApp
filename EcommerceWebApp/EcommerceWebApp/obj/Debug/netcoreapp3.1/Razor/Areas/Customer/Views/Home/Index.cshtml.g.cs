#pragma checksum "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c314e7b6ee3ebf78608eae6b52d240d7769e666a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\_ViewImports.cshtml"
using EcommerceWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\_ViewImports.cshtml"
using EcommerceWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c314e7b6ee3ebf78608eae6b52d240d7769e666a", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddc4f3828d4e5c0438fbd06aebb51368105423da", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EcommerceWebApp.Models.ViewModels.IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ThumbnailAreaPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\n\r\n");
#nullable restore
#line 5 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
 if (Model.Coupon.ToList().Count > 0)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <div class=\"carousel\" data-ride=\"carousel\" data-interval=\"3500\">\r\n");
#nullable restore
#line 10 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
             for (int i = 0; i < Model.Coupon.Count(); i++)
            {
                if (i == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item active\">\r\n");
#nullable restore
#line 15 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
                          
                            var base64 = Convert.ToBase64String(Model.Coupon.ToList()[i].Picture);
                            var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 657, "\"", 670, 1);
#nullable restore
#line 20 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 663, imgsrc, 663, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"80\" class=\"d-block w-25\" />\r\n\r\n                    </div>\r\n");
#nullable restore
#line 23 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
                }
                else 
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item\">\r\n");
#nullable restore
#line 27 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
                          
                            var base64 = Convert.ToBase64String(Model.Coupon.ToList()[i].Picture);
                            var imgsrc = string.Format("data:image/jpg;base64,{0}", base64);
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1128, "\"", 1141, 1);
#nullable restore
#line 32 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 1134, imgsrc, 1134, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"80\" class=\"d-block w-25\" />\r\n\r\n                    </div>\r\n");
#nullable restore
#line 35 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 40 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br /><br />\r\n\r\n<div class=\" backgroundWhite container\" >\r\n\r\n    <ul id=\"menu-filters\" class=\"menu-filter-list list-inline text-center\">\r\n        <li class=\"filter active btn btn-secondary ml-1 mr-2\">Show All</li>\r\n");
#nullable restore
#line 50 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
         foreach (var item in Model.Category)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"filter ml-1 mr-2\">");
#nullable restore
#line 52 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 53 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n\r\n\r\n");
#nullable restore
#line 57 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
     foreach (var category in Model.Category)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\" id=\"menu-wrapper\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c314e7b6ee3ebf78608eae6b52d240d7769e666a8823", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 60 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.MenuItem.Where(u=>u.Category.Name.Equals(category.Name));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 62 "C:\Users\kaunda.dum\Documents\GitHub\EcommerceWebApp\EcommerceWebApp\EcommerceWebApp\Areas\Customer\Views\Home\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EcommerceWebApp.Models.ViewModels.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
