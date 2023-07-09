using CinemaProject.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.IO;
using GemBox.Document;

namespace CinemaProject.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMovieService _movieService;

        public OrderController(IOrderService orderService, IMovieService movieService)
        {
            _orderService = orderService;
            _movieService = movieService;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            return View(_orderService.GetAllOrders());
        }

        public IActionResult Details(Guid orderId)
        {
            var model = new Domain.BaseEntity
            {
                Id = orderId
            };
            return View(_orderService.GetOrder(model));
        }

        public FileContentResult CreateInvoice(Guid orderId)
        {
            var model = new Domain.BaseEntity
            {
                Id = orderId
            };
            var data = _orderService.GetOrder(model);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");

            var document = DocumentModel.Load(path);
            document.Content.Replace("{{OrderNo}}", data.Id.ToString());
            document.Content.Replace("{{TicketHolder}}", data.TicketHolder.FirstName + " " + data.TicketHolder.LastName + " - " + data.TicketHolder.Email);
            StringBuilder sb = new StringBuilder();
            var totalPrice = 0.0;
            foreach (var ticket in data.TicketsInOrder)
            {
                totalPrice += ticket.Quantity * ticket.Ticket.Price;
                sb.AppendLine("Ticket for movie: " + _movieService.GetMovieById(ticket.Ticket.ForMovieId).Name + " - " + ticket.Quantity + " X " + ticket.Ticket.Price + "$");
            }
            document.Content.Replace("{{TicketList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", totalPrice.ToString() + "$");

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportedInvoice.pdf");
        }
    }
}
