#pragma checksum "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dce5dbcb6c32e763665767c78fe06a38ffb939fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_Grade), @"mvc.1.0.view", @"/Views/Professor/Grade.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Professor/Grade.cshtml", typeof(AspNetCore.Views_Professor_Grade))]
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
#line 1 "C:\Users\Todd\source\repos\Phase3\LMS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Todd\source\repos\Phase3\LMS\Views\_ViewImports.cshtml"
using LMS;

#line default
#line hidden
#line 3 "C:\Users\Todd\source\repos\Phase3\LMS\Views\_ViewImports.cshtml"
using LMS.Models;

#line default
#line hidden
#line 4 "C:\Users\Todd\source\repos\Phase3\LMS\Views\_ViewImports.cshtml"
using LMS.Models.AccountViewModels;

#line default
#line hidden
#line 5 "C:\Users\Todd\source\repos\Phase3\LMS\Views\_ViewImports.cshtml"
using LMS.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dce5dbcb6c32e763665767c78fe06a38ffb939fc", @"/Views/Professor/Grade.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"363c4fd446cecdc21217d95f921ea2b5901a3ca3", @"/Views/_ViewImports.cshtml")]
    public class Views_Professor_Grade : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
  
    ViewData["Title"] = "Grade";
    Layout = "~/Views/Shared/ProfessorLayout.cshtml";

#line default
#line hidden
            BeginContext(98, 10, true);
            WriteLiteral("\r\n<html>\r\n");
            EndContext();
            BeginContext(108, 936, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce5dbcb6c32e763665767c78fe06a38ffb939fc4032", async() => {
                BeginContext(114, 923, true);
                WriteLiteral(@"
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <style>
    body {
      font-family: ""Lato"", sans-serif;
    }

    .sidenav {
      /*width: 130px;
      height: 210px;
      position: fixed;
      z-index: 1;
      top: 80px;
      left: 10px;*/
      width: 130px;
      height: 210px;
      position: fixed;
      left: 0;
      right: 0;
      /*margin-left: auto;
      margin-right: auto;*/
      z-index: 1;
      top: 50px;

      background: #eee;
      overflow-x: hidden;
      padding: 8px 0;
    }

      .sidenav a {
        padding: 6px 8px 6px 16px;
        text-decoration: none;
        font-size: 18px;
        color: #2196F3;
        display: block;
      }

        .sidenav a:hover {
          color: #064579;
        }

    .main {
      margin-left: 140px;
      min-height: 200px;
      padding: 0px 10px;
    }
  </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1044, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1046, 916, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce5dbcb6c32e763665767c78fe06a38ffb939fc6143", async() => {
                BeginContext(1052, 35, true);
                WriteLiteral("\r\n\r\n  <div class=\"sidenav\">\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1087, "\'", 1210, 8);
                WriteAttributeValue("", 1094, "/Professor/Class?subject=", 1094, 25, true);
#line 59 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1119, ViewData["subject"], 1119, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1139, "&num=", 1139, 5, true);
#line 59 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1144, ViewData["num"], 1144, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1160, "&season=", 1160, 8, true);
#line 59 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1168, ViewData["season"], 1168, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1187, "&year=", 1187, 6, true);
#line 59 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1193, ViewData["year"], 1193, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1211, 24, true);
                WriteLiteral(">Assignments</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1235, "\'", 1361, 8);
                WriteAttributeValue("", 1242, "/Professor/Students?subject=", 1242, 28, true);
#line 60 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1270, ViewData["subject"], 1270, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1290, "&num=", 1290, 5, true);
#line 60 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1295, ViewData["num"], 1295, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1311, "&season=", 1311, 8, true);
#line 60 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1319, ViewData["season"], 1319, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1338, "&year=", 1338, 6, true);
#line 60 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1344, ViewData["year"], 1344, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1362, 21, true);
                WriteLiteral(">Students</a>\r\n    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1383, "\'", 1511, 8);
                WriteAttributeValue("", 1390, "/Professor/Categories?subject=", 1390, 30, true);
#line 61 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1420, ViewData["subject"], 1420, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 1440, "&num=", 1440, 5, true);
#line 61 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1445, ViewData["num"], 1445, 16, false);

#line default
#line hidden
                WriteAttributeValue("", 1461, "&season=", 1461, 8, true);
#line 61 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1469, ViewData["season"], 1469, 19, false);

#line default
#line hidden
                WriteAttributeValue("", 1488, "&year=", 1488, 6, true);
#line 61 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
WriteAttributeValue("", 1494, ViewData["year"], 1494, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1512, 443, true);
                WriteLiteral(@">Assignment Categories</a>
  </div>


  <div class=""main"">

    <h4>Grade Submission</h4>
    <div id=""submissioncontents""></div>
    <hr />
    <div>
      <input type=""text"" name=""Score"" id=""Score"" class=""form-control"" placeholder=""0"" required="""" />
    </div>

    <div>
      <input class=""btn btn-primary"" name=""submitButton"" id=""btnSave"" value=""Submit Score"" type=""button"" onclick=""SubmitScore()"">
    </div>

  </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1962, 21, true);
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2004, 193, true);
                WriteLiteral("\r\n  <script type=\"text/javascript\">\r\n\r\n    LoadData();\r\n\r\n\r\n    function SubmitScore() {\r\n\r\n      var score = Number($(\"#Score\").val());\r\n\r\n      $.ajax({\r\n        type: \'POST\',\r\n        url: \'");
                EndContext();
                BeginContext(2198, 42, false);
#line 99 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
         Write(Url.Action("GradeSubmission", "Professor"));

#line default
#line hidden
                EndContext();
                BeginContext(2240, 70, true);
                WriteLiteral("\',\r\n        dataType: \'json\',\r\n\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(2311, 19, false);
#line 103 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(2330, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(2358, 15, false);
#line 104 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(2373, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(2398, 18, false);
#line 105 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(2416, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(2445, 16, false);
#line 106 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(2461, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(2488, 15, false);
#line 107 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(2503, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(2528, 17, false);
#line 108 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(2545, 20, true);
                WriteLiteral("\',\r\n          uid: \'");
                EndContext();
                BeginContext(2566, 15, false);
#line 109 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
           Write(ViewData["uid"]);

#line default
#line hidden
                EndContext();
                BeginContext(2581, 628, true);
                WriteLiteral(@"',
          score: score},
        success: function (data, status) {
          alert(JSON.stringify(data));
          if (!data.success) {
            alert(""Unable to submit score"");
          }
          location.reload();
          //LoadData();
        },
        error: function (ex) {
          var r = jQuery.parseJSON(response.responseText);
          alert(""Message: "" + r.Message);
          alert(""StackTrace: "" + r.StackTrace);
          alert(""ExceptionType: "" + r.ExceptionType);
        }
        });

    }

    function LoadData() {

      $.ajax({
        type: 'POST',
        url: '");
                EndContext();
                BeginContext(3210, 41, false);
#line 133 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
         Write(Url.Action("GetSubmissionText", "Common"));

#line default
#line hidden
                EndContext();
                BeginContext(3251, 68, true);
                WriteLiteral("\',\r\n        dataType: \'text\',\r\n        data: {\r\n          subject: \'");
                EndContext();
                BeginContext(3320, 19, false);
#line 136 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
               Write(ViewData["subject"]);

#line default
#line hidden
                EndContext();
                BeginContext(3339, 27, true);
                WriteLiteral("\',\r\n          num: Number(\'");
                EndContext();
                BeginContext(3367, 15, false);
#line 137 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                  Write(ViewData["num"]);

#line default
#line hidden
                EndContext();
                BeginContext(3382, 24, true);
                WriteLiteral("\'),\r\n          season: \'");
                EndContext();
                BeginContext(3407, 18, false);
#line 138 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
              Write(ViewData["season"]);

#line default
#line hidden
                EndContext();
                BeginContext(3425, 28, true);
                WriteLiteral("\',\r\n          year: Number(\'");
                EndContext();
                BeginContext(3454, 16, false);
#line 139 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                   Write(ViewData["year"]);

#line default
#line hidden
                EndContext();
                BeginContext(3470, 26, true);
                WriteLiteral("\'),\r\n          category: \'");
                EndContext();
                BeginContext(3497, 15, false);
#line 140 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
                Write(ViewData["cat"]);

#line default
#line hidden
                EndContext();
                BeginContext(3512, 24, true);
                WriteLiteral("\',\r\n          asgname: \'");
                EndContext();
                BeginContext(3537, 17, false);
#line 141 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
               Write(ViewData["aname"]);

#line default
#line hidden
                EndContext();
                BeginContext(3554, 20, true);
                WriteLiteral("\',\r\n          uid: \'");
                EndContext();
                BeginContext(3575, 15, false);
#line 142 "C:\Users\Todd\source\repos\Phase3\LMS\Views\Professor\Grade.cshtml"
           Write(ViewData["uid"]);

#line default
#line hidden
                EndContext();
                BeginContext(3590, 655, true);
                WriteLiteral(@"'},
        success: function (data, status) {
          //alert(data);
          

          var submissiondiv = document.getElementById(""submissioncontents"");
          if (data == """") {
            submissiondiv.innerHTML = ""(none)"";
          }
          else {
            submissiondiv.innerHTML = data;
          }
          
        },
        error: function (ex) {
          var r = jQuery.parseJSON(response.responseText);
          alert(""Message: "" + r.Message);
          alert(""StackTrace: "" + r.StackTrace);
          alert(""ExceptionType: "" + r.ExceptionType);
        }
        });
        
    }

  </script>

");
                EndContext();
            }
            );
            BeginContext(4248, 4, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591