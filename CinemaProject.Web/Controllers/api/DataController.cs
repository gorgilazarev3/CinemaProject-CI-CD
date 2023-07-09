using CinemaProject.Domain.DomainModels;
using CinemaProject.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public DataController(ITicketService ticketService, IUserService userService, IMovieService movieService)
        {
            _ticketService = ticketService;
            _userService = userService;
            _movieService = movieService;
        }

        [HttpGet("[action]")]
        public List<Ticket> GetAllTickets(MovieCategory ?genre)
        {
            var allTickets = _ticketService.GetAllTickets();
            foreach(var ticket in allTickets)
            {
                ticket.Movie = _movieService.GetMovieById(ticket.ForMovieId);
            }
            if (genre != null)
            {
                allTickets = allTickets.Where(t => t.Movie.Category.Equals(genre));
            }
            return allTickets.ToList();
        }
    }
}
