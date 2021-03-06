#pragma checksum "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47b92ea1cc8bedf31dd7f7a7c79a78823c2f3609"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Dashboard), @"mvc.1.0.view", @"/Views/Dashboard/Dashboard.cshtml")]
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
#line 1 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\_ViewImports.cshtml"
using ResultArchive;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\_ViewImports.cshtml"
using ResultArchive.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b92ea1cc8bedf31dd7f7a7c79a78823c2f3609", @"/Views/Dashboard/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40b498c2ad2b919b39b2b0b2034b5b8c8b41e044", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultArchive.ViewModels.DashboardViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partials/_Sidebar.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partials/_Footer.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
  
    var user = await UserManager.GetUserAsync(User);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("LeftSidebar", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "47b92ea1cc8bedf31dd7f7a7c79a78823c2f36094323", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"<!-- Page content -->
<div class=""page-content"">
    <div class=""container-fluid"">
        <div class=""row justify-content-center"">
            <div class=""col-md-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""float-right"">
                            <i class=""dripicons-user-group font-24 text-secondary""></i>
                        </div>
                        <span class=""badge badge-danger"">Users</span>
                        <h3 class=""font-weight-bold"">");
#nullable restore
#line 24 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
                                                Write(Model.UserCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p class=""mb-0 text-muted text-truncate""><span class=""text-success""><i class=""mdi mdi-trending-up""></i>Total </span>Number of User</p>
                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""float-right"">
                            <i class=""dripicons-graduation  font-20 text-secondary""></i>
                        </div>
                        <span class=""badge badge-info"">Schools</span>
                        <h3 class=""font-weight-bold"">");
#nullable restore
#line 36 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
                                                Write(Model.SchoolCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p class=""mb-0 text-muted text-truncate""><span class=""text-success""><i class=""mdi mdi-trending-up""></i>Total </span>Number of School</p>
                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""float-right"">
                            <i class=""dripicons-document font-20 text-secondary""></i>
                        </div>
                        <span class=""badge badge-warning"">Results</span>
                        <h3 class=""font-weight-bold"">");
#nullable restore
#line 48 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
                                                Write(Model.ResultCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p class=""mb-0 text-muted text-truncate""><span class=""text-danger""><i class=""mdi mdi-trending-down""></i>Total </span> Number of Results</p>
                    </div>
                </div>
            </div>
            <div class=""col-md-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""float-right"">
                            <i class=""dripicons-clockwise font-20 text-secondary""></i>
                        </div>
                        <span class=""badge badge-success"">Sessions</span>
                        <h3 class=""font-weight-bold"">");
#nullable restore
#line 60 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
                                                Write(Model.SessionCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <p class=""mb-0 text-muted text-truncate""><span class=""text-success""><i class=""mdi mdi-trending-up""></i>Total</span> Number of Sessions</p>
                    </div>
                </div>
            </div>
        </div>

    </div><!-- container -->

    <div class=""row"">
        <div class=""col-lg-8 offset-2"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""mt-0 header-title"">Welcome ");
#nullable restore
#line 73 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml"
                                                     Write(user.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"!</a></h4>
                    <p class=""text-muted mb-4 font-13"">
                        Hope you are having a great day

                    </p>

                    <blockquote class=""blockquote"">
                        <p>This is an archive, dont mess arround with the records here.</p>
                        <footer class=""blockquote-footer font-14"">Crafted with <cite title=""Source Title"">Love</cite></footer>
                    </blockquote>

                </div><!--end card-body-->
            </div><!--end card-->
        </div><!--end col-->

    </div><!--end row-->

    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "47b92ea1cc8bedf31dd7f7a7c79a78823c2f360910618", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<!-- end page content -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultArchive.ViewModels.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
