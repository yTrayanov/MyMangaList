#pragma checksum "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed80a51ea847a36ec82bb7919cc1462554cf9e67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyMangaList.Web.Areas.Users.Group.Areas_Users_Views_Group_Details), @"mvc.1.0.view", @"/Areas/Users/Views/Group/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Users/Views/Group/Details.cshtml", typeof(MyMangaList.Web.Areas.Users.Group.Areas_Users_Views_Group_Details))]
namespace MyMangaList.Web.Areas.Users.Group
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed80a51ea847a36ec82bb7919cc1462554cf9e67", @"/Areas/Users/Views/Group/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c1d819689377b9c6d3567fcfc262454694daf4b", @"/Areas/Users/Views/_ViewImports.cshtml")]
    public class Areas_Users_Views_Group_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
  
    ViewData["Title"] = "Details for " +Model.Title;

#line default
#line hidden
            BeginContext(85, 18, true);
            WriteLiteral("\r\n<h2>Details for ");
            EndContext();
            BeginContext(104, 11, false);
#line 6 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(115, 49, true);
            WriteLiteral(" group</h2>\r\n<p><strong>Creator</strong></p>\r\n<p>");
            EndContext();
            BeginContext(165, 13, false);
#line 8 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
Write(Model.Creator);

#line default
#line hidden
            EndContext();
            BeginContext(178, 37, true);
            WriteLiteral("</p>\r\n<p><strong>Users</strong></p>\r\n");
            EndContext();
#line 10 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
 foreach (var member in Model.Members)
{

#line default
#line hidden
            BeginContext(258, 7, true);
            WriteLiteral("    <p>");
            EndContext();
            BeginContext(266, 15, false);
#line 12 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
  Write(member.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(281, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 13 "C:\Users\Yavor\source\repos\MyMangaList\MyMangaList.Web\Areas\Users\Views\Group\Details.cshtml"
}

#line default
#line hidden
            BeginContext(290, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591