#pragma checksum "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebd2feb9376c24e36f2d50fc14a8ddf954411b69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowActivity), @"mvc.1.0.view", @"/Views/Home/ShowActivity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ShowActivity.cshtml", typeof(AspNetCore.Views_Home_ShowActivity))]
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
#line 1 "C:\Users\Vince\NET_Stack\BeltExam\Views\_ViewImports.cshtml"
using BeltExam;

#line default
#line hidden
#line 2 "C:\Users\Vince\NET_Stack\BeltExam\Views\_ViewImports.cshtml"
using BeltExam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd2feb9376c24e36f2d50fc14a8ddf954411b69", @"/Views/Home/ShowActivity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84119000702c45f5036e3e300b27d647b6aca13", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowActivity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RecActivity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
  ViewData["Title"] = "Activity";

#line default
#line hidden
            BeginContext(57, 105, true);
            WriteLiteral("<div class=\"container\">\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n      <span style=\"color:blue\" ><h1>");
            EndContext();
            BeginContext(163, 19, false);
#line 6 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
                               Write(Model.ActivityTitle);

#line default
#line hidden
            EndContext();
            BeginContext(182, 49, true);
            WriteLiteral("</h1></span>\r\n    </div>\r\n    <div class=\"col\">\r\n");
            EndContext();
#line 9 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
       if (@Model.UserId==ViewBag.UserId)
          {

#line default
#line hidden
            BeginContext(287, 12, true);
            WriteLiteral("          <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 299, "\"", 342, 2);
            WriteAttributeValue("", 306, "/CancelActivity/", 306, 16, true);
#line 11 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
WriteAttributeValue("", 322, Model.RecActivityID, 322, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(343, 44, true);
            WriteLiteral(" type=\"button\" value=\"Delete\"> Delete </a>\r\n");
            EndContext();
#line 12 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
          }
          else if (@Model.Particpants.Any(u=>u.UserId==ViewBag.UserId))
          {

#line default
#line hidden
            BeginContext(486, 16, true);
            WriteLiteral("              <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 502, "\"", 537, 2);
            WriteAttributeValue("", 509, "/UNRSVP/", 509, 8, true);
#line 15 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
WriteAttributeValue("", 517, Model.RecActivityID, 517, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(538, 42, true);
            WriteLiteral(" type=\"button\" value=\"Leave\"> Leave </a>\r\n");
            EndContext();
#line 16 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
          }
          else 
          {

#line default
#line hidden
            BeginContext(623, 14, true);
            WriteLiteral("            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 637, "\"", 670, 2);
            WriteAttributeValue("", 644, "/RSVP/", 644, 6, true);
#line 19 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
WriteAttributeValue("", 650, Model.RecActivityID, 650, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(671, 38, true);
            WriteLiteral(" type=\"button\" value=\"Join\">Join</a>\r\n");
            EndContext();
#line 20 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
          }

#line default
#line hidden
            BeginContext(722, 184, true);
            WriteLiteral("    </div>\r\n  </div>\r\n</div>\r\n<hr>\r\n<div class=\"container\">\r\n  <div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n<h3 class=\"text-nowrap\" >Event Coordinator: <span style=\"color:blue\" ><u>");
            EndContext();
            BeginContext(907, 27, false);
#line 28 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
                                                                    Write(Model.Coordinator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(934, 142, true);
            WriteLiteral("</u></span></h3>\r\n  </div>\r\n</div>\r\n<h3>Description</h3>\r\n  <div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n    <textarea rows=\"4\" cols=\"50\"> ");
            EndContext();
            BeginContext(1077, 17, false);
#line 34 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
                             Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1094, 186, true);
            WriteLiteral("</textarea>\r\n      </div>\r\n</div>\r\n<div class=\"container\"> \r\n  <div class=\"row\">\r\n    <div class=\"col-sm-1\"></div>\r\n        <ul><u><h3>Participants:</h3></u>\r\n        <div class=\"col\">\r\n");
            EndContext();
#line 42 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
       foreach(RSVP rsvp in @Model.Particpants) 
      {

#line default
#line hidden
            BeginContext(1339, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(1352, 25, false);
#line 44 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
       Write(rsvp.Participant.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(1377, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 45 "C:\Users\Vince\NET_Stack\BeltExam\Views\Home\ShowActivity.cshtml"
      }  

#line default
#line hidden
            BeginContext(1395, 111, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n<div class=\"container\">\r\n  <div class=\"row\">\r\n</div>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RecActivity> Html { get; private set; }
    }
}
#pragma warning restore 1591
