using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain.DTO;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace CinemaProject.Web.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExportTicketsToExcel(MovieCategory ?genre)
        {
            string fileName = "Tickets.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            HttpClient client = new HttpClient();
            string url = "https://localhost:44315/api/Data/GetAllTickets?";
            url += "genre=" + genre;
            HttpResponseMessage response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsAsync<List<TicketDTO>>().Result;
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Tickets");

                worksheet.Cell(1, 1).Value = "Ticket #";
                worksheet.Cell(1, 2).Value = "Movie";
                worksheet.Cell(1, 3).Value = "Genre";
                worksheet.Cell(1, 4).Value = "Date";
                worksheet.Cell(1, 5).Value = "Price";


                for (int i = 1; i <= data.Count; i++)
                {
                    var ticket = data.ElementAt(i - 1);
                    worksheet.Cell(i + 1, 1).Value = ticket.Id.ToString();
                    worksheet.Cell(i + 1, 2).Value = ticket.Movie.Name;
                    worksheet.Cell(i + 1, 3).Value = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ticket.Movie.Category.ToString().ToLower());
                    worksheet.Cell(i + 1, 4).Value = ticket.ValidForDate.ToShortDateString();
                    worksheet.Cell(i + 1, 5).Value = ticket.Price.ToString() + "$";

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
        }
    }
}
