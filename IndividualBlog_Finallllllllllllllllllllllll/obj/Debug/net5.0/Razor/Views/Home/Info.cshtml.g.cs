#pragma checksum "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95a15e151f3d061c075644166836fc19ea2330e4473ba05d4bac2659d90c7730"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Info), @"mvc.1.0.view", @"/Views/Home/Info.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\_ViewImports.cshtml"
using IndividualBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\_ViewImports.cshtml"
using IndividualBlog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"95a15e151f3d061c075644166836fc19ea2330e4473ba05d4bac2659d90c7730", @"/Views/Home/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d285bb11aaa713f36cf2cc3241d9a54b4b37e7c0e3e8fdaeaecc844c0f51c0d5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndividualBlog.Models.User>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
  
    ViewData["Title"] = "Info";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Thông tin tài khoản</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.FirtName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.FirtName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Adress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Adress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Intro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Intro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 67 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Created_At));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 70 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Created_At));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 73 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayNameFor(model => model.Updated_At));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 76 "D:\Fpoly\IndividualBlog_VietHoa100_phan_tram_v1_6\IndividualBlog\Views\Home\Info.cshtml"
       Write(Html.DisplayFor(model => model.Updated_At));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95a15e151f3d061c075644166836fc19ea2330e4473ba05d4bac2659d90c773010792", async() => {
                WriteLiteral("Trở về");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndividualBlog.Models.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591