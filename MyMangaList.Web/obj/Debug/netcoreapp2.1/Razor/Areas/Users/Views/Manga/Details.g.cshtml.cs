#pragma checksum "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a9af567930596741551f73c7039fc9a1a4ecfc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyMangaList.Web.Areas.Users.Manga.Areas_Users_Views_Manga_Details), @"mvc.1.0.view", @"/Areas/Users/Views/Manga/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Users/Views/Manga/Details.cshtml", typeof(MyMangaList.Web.Areas.Users.Manga.Areas_Users_Views_Manga_Details))]
namespace MyMangaList.Web.Areas.Users.Manga
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\_ViewImports.cshtml"
using MyMangaList.Models;

#line default
#line hidden
#line 2 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\_ViewImports.cshtml"
using MyMangaList.ViewModels.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\_ViewImports.cshtml"
using MyMangaList.ViewModels.BindingModels;

#line default
#line hidden
#line 4 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\_ViewImports.cshtml"
using MyMangaList.ViewModels.MixedModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a9af567930596741551f73c7039fc9a1a4ecfc7", @"/Areas/Users/Views/Manga/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c1d819689377b9c6d3567fcfc262454694daf4b", @"/Areas/Users/Views/_ViewImports.cshtml")]
    public class Areas_Users_Views_Manga_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MangaDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manga", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadStory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submint"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Add to favourites"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Favour", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
  
    ViewData["Title"] = "Details for " + Model.Title;

#line default
#line hidden
            BeginContext(92, 19, true);
            WriteLiteral("\r\n<h2>Details for \"");
            EndContext();
            BeginContext(112, 11, false);
#line 6 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
            Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(123, 14, true);
            WriteLiteral("\"</h2>\r\n\r\n<img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 137, "\"", 155, 1);
#line 8 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
WriteAttributeValue("", 143, Model.Image, 143, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(156, 16, true);
            WriteLiteral(" />\r\n<p><strong>");
            EndContext();
            BeginContext(173, 12, false);
#line 9 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
      Write(Model.Author);

#line default
#line hidden
            EndContext();
            BeginContext(185, 18, true);
            WriteLiteral("</strong></p>\r\n<p>");
            EndContext();
            BeginContext(204, 10, false);
#line 10 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(214, 9, true);
            WriteLiteral("</p>\r\n<p>");
            EndContext();
            BeginContext(224, 17, false);
#line 11 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
Write(Model.LastUpdated);

#line default
#line hidden
            EndContext();
            BeginContext(241, 9, true);
            WriteLiteral("</p>\r\n<p>");
            EndContext();
            BeginContext(251, 22, false);
#line 12 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
Write(Model.ShortDescription);

#line default
#line hidden
            EndContext();
            BeginContext(273, 9, true);
            WriteLiteral("</p>\r\n<p>");
            EndContext();
            BeginContext(282, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a33314756f8471787ba05ef20455743", async() => {
                BeginContext(374, 51, true);
                WriteLiteral("\r\n    If you find this manga fun , click here\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 13 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
                                                                       WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(429, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(435, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9b386663a784081bf2b829c7c2f7c64", async() => {
                BeginContext(569, 6, true);
                WriteLiteral("Favour");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 16 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Manga\Details.cshtml"
                                                                                                               WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(584, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MangaDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
