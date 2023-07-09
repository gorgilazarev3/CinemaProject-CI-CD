#pragma checksum "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17502163738a35712577b7cfd51fd2ae45e5d9b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
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
#line 1 "E:\Projects\CinemaProject\CinemaProject.Web\Views\_ViewImports.cshtml"
using CinemaProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
using CinemaProject.Domain.DomainModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
using CinemaProject.Service.Interface;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17502163738a35712577b7cfd51fd2ae45e5d9b6", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85b90398e30e0a238517f929e94cd66f37b0d18c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <p>\r\n        <a class=\"btn btn-warning\">");
#nullable restore
#line 9 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                              Write(Model.TicketHolder.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 9 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                                          Write(Model.TicketHolder.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                                                                        Write(Model.TicketHolder.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </p>\r\n\r\n");
#nullable restore
#line 12 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
     for (int i = 0; i < Model.TicketsInOrder.Count(); i++)
    {
        var item = Model.TicketsInOrder.ElementAt(i);

        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 19 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3 m-4\">\r\n                <div class=\"card\" style=\"width: 18rem; height: 30rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 680, "\"", 746, 1);
#nullable restore
#line 23 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
WriteAttributeValue("", 686, movieService.GetMovieById(@item.Ticket.ForMovieId).ImageURL, 686, 60, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 50%;\" alt=\"Image for ticket!\">\r\n\r\n                    <div class=\"card-body\">\r\n                        <h3 class=\"card-title\">");
#nullable restore
#line 26 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                          Write(movieService.GetMovieById(@item.Ticket.ForMovieId).Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 27 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                        Write(movieService.GetMovieById(@item.Ticket.ForMovieId).Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n                        <h6>Price: $");
#nullable restore
#line 30 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                               Write(item.Ticket.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <h6>Quantity: ");
#nullable restore
#line 31 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                 Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <h6>Total: $");
#nullable restore
#line 32 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
                                Write(item.Ticket.Price * item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 37 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"


            if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 42 "E:\Projects\CinemaProject\CinemaProject.Web\Views\Order\Details.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IMovieService movieService { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591