#pragma checksum "C:\Users\etec\Downloads\AtlasP\Views\Shared\_Settings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d4e826060bcdc992e2986d12f99cec3a3609d1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Settings), @"mvc.1.0.view", @"/Views/Shared/_Settings.cshtml")]
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
#line 1 "C:\Users\etec\Downloads\AtlasP\Views\_ViewImports.cshtml"
using AtlasP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\etec\Downloads\AtlasP\Views\_ViewImports.cshtml"
using AtlasP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d4e826060bcdc992e2986d12f99cec3a3609d1c", @"/Views/Shared/_Settings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0e24b4ba95fa178185d2387e97b4da64c5774ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Settings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""card shadow-lg"">
    <div class=""card-header pb-0 pt-3"">
        <div class=""float-start"">
            <h5 class=""mt-3 mb-0"">Material UI Configurator</h5>
            <p>See our dashboard options.</p>
        </div>
        <div class=""float-end mt-4"">
            <button class=""btn btn-link text-dark p-0 fixed-plugin-close-button"">
                <i class=""material-icons"">clear</i>
            </button>
        </div>
        <!-- End Toggle Button -->
    </div>
    <hr class=""horizontal dark my-1"">
    <div class=""card-body pt-sm-3 pt-0"">
        <!-- Sidebar Backgrounds -->
        <div>
            <h6 class=""mb-0"">Sidebar Colors</h6>
        </div>
        <a href=""javascript:void(0)"" class=""switch-trigger background-color"">
            <div class=""badge-colors my-2 text-start"">
                <span class=""badge filter bg-gradient-primary active"" data-color=""primary""
                    onclick=""sidebarColor(this)""></span>
                <span class=""badge filter bg");
            WriteLiteral(@"-gradient-dark"" data-color=""dark"" onclick=""sidebarColor(this)""></span>
                <span class=""badge filter bg-gradient-info"" data-color=""info"" onclick=""sidebarColor(this)""></span>
                <span class=""badge filter bg-gradient-success"" data-color=""success"" onclick=""sidebarColor(this)""></span>
                <span class=""badge filter bg-gradient-warning"" data-color=""warning"" onclick=""sidebarColor(this)""></span>
                <span class=""badge filter bg-gradient-danger"" data-color=""danger"" onclick=""sidebarColor(this)""></span>
            </div>
        </a>
        <!-- Sidenav Type -->
        <div class=""mt-3"">
            <h6 class=""mb-0"">Sidenav Type</h6>
            <p class=""text-sm"">Choose between 2 different sidenav types.</p>
        </div>
        <div class=""d-flex"">
            <button class=""btn bg-gradient-dark px-3 mb-2 active"" data-class=""bg-gradient-dark""
                onclick=""sidebarType(this)"">Dark</button>
            <button class=""btn bg-gradient-dark px-");
            WriteLiteral(@"3 mb-2 ms-2"" data-class=""bg-transparent""
                onclick=""sidebarType(this)"">Transparent</button>
            <button class=""btn bg-gradient-dark px-3 mb-2 ms-2"" data-class=""bg-white""
                onclick=""sidebarType(this)"">White</button>
        </div>
        <p class=""text-sm d-xl-none d-block mt-2"">You can change the sidenav type just on desktop view.</p>
        <!-- Navbar Fixed -->
        <div class=""mt-3 d-flex"">
            <h6 class=""mb-0"">Navbar Fixed</h6>
            <div class=""form-check form-switch ps-0 ms-auto my-auto"">
                <input class=""form-check-input mt-1 ms-auto"" type=""checkbox"" id=""navbarFixed""
                    onclick=""navbarFixed(this)"">
            </div>
        </div>
        <hr class=""horizontal dark my-3"">
        <div class=""mt-2 d-flex"">
            <h6 class=""mb-0"">Light / Dark</h6>
            <div class=""form-check form-switch ps-0 ms-auto my-auto"">
                <input class=""form-check-input mt-1 ms-auto"" type=""checkbox"" id=""");
            WriteLiteral("dark-version\" onclick=\"darkMode(this)\">\r\n            </div>\r\n        </div>\r\n        <hr class=\"horizontal dark my-sm-4\">\r\n        <a class=\"btn btn-outline-dark w-100\"");
            BeginWriteAttribute("href", " href=\"", 3240, "\"", 3247, 0);
            EndWriteAttribute();
            WriteLiteral(@">View documentation</a>
        <div class=""w-100 text-center"">
            <a class=""github-button"" href=""https://github.com/creativetimofficial/material-dashboard""
                data-icon=""octicon-star"" data-size=""large"" data-show-count=""true""
                aria-label=""Star creativetimofficial/material-dashboard on GitHub"">Star</a>
            <h6 class=""mt-3"">Thank you for sharing!</h6>
            <a href=""https://twitter.com/intent/tweet?text=Check%20Material%20UI%20Dashboard%20made%20by%20%40CreativeTim%20%23webdesign%20%23dashboard%20%23bootstrap5&amp;url=https%3A%2F%2Fwww.creative-tim.com%2Fproduct%2Fsoft-ui-dashboard""
                class=""btn btn-dark mb-0 me-2"" target=""_blank"">
                <i class=""fab fa-twitter me-1"" aria-hidden=""true""></i> Tweet
            </a>
            <a href=""https://www.facebook.com/sharer/sharer.php?u=https://www.creative-tim.com/product/material-dashboard""
                class=""btn btn-dark mb-0 me-2"" target=""_blank"">
                <i class=""fa");
            WriteLiteral("b fa-facebook-square me-1\" aria-hidden=\"true\"></i> Share\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591