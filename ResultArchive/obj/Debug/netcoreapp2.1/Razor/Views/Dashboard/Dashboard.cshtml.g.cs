#pragma checksum "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\Dashboard\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3de941df4b9ec22c03ef35bbf28fa31617506e1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Dashboard), @"mvc.1.0.view", @"/Views/Dashboard/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/Dashboard.cshtml", typeof(AspNetCore.Views_Dashboard_Dashboard))]
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
#line 1 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\_ViewImports.cshtml"
using ResultArchive;

#line default
#line hidden
#line 2 "C:\Projects\C#\Web\ResultArchive\ResultArchive\Views\_ViewImports.cshtml"
using ResultArchive.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3de941df4b9ec22c03ef35bbf28fa31617506e1c", @"/Views/Dashboard/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40b498c2ad2b919b39b2b0b2034b5b8c8b41e044", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partials/_Sidebar.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Partials/_Footer.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("LeftSidebar", async() => {
                BeginContext(24, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(30, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b6246743ba0d468d99e2f2e5581fc082", async() => {
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
                EndContext();
                BeginContext(81, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(86, 3040, true);
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
                            <h3 class=""font-weight-bold"">10</h3>
                            <p class=""mb-0 text-muted text-truncate""><span class=""text-success""><i class=""mdi mdi-trending-up""></i>Total </span>Number of User</p>
                        </div>
                    </div>
                </div>
                <div class=""col-md-3"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <div class=""float");
            WriteLiteral(@"-right"">
                                <i class=""dripicons-graduation  font-20 text-secondary""></i>
                            </div>
                            <span class=""badge badge-info"">Schools</span>
                            <h3 class=""font-weight-bold"">24</h3>
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
                            <h3 class=""font-weight-bold"">8400</h3>
                            <p class");
            WriteLiteral(@"=""mb-0 text-muted text-truncate""><span class=""text-danger""><i class=""mdi mdi-trending-down""></i>Total </span> Number of Results</p>
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
                            <h3 class=""font-weight-bold"">40</h3>
                            <p class=""mb-0 text-muted text-truncate""><span class=""text-success""><i class=""mdi mdi-trending-up""></i>Total</span> Number of Sessions</p>
                        </div>
                    </div>
                </div>
            </div>

        </div><!-- container -->

        ");
            EndContext();
            BeginContext(3126, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "05261295e9194759b84f58c72dde602d", async() => {
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
            EndContext();
            BeginContext(3176, 39, true);
            WriteLiteral("\r\n    </div>\r\n<!-- end page content -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
