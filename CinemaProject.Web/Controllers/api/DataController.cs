using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain.DTO;
using CinemaProject.Domain.Identity;
using CinemaProject.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        private readonly UserManager<CinemaUser> _userManager;

        public DataController(ITicketService ticketService, IUserService userService, IMovieService movieService, UserManager<CinemaUser> userManager)
        {
            _ticketService = ticketService;
            _userService = userService;
            _movieService = movieService;
            _userManager = userManager;
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

        [HttpPost("[action]")]
        public async Task<bool> ImportUsersFromExcel(List<RegistrationUserDTO> users)
        {
            var status = true;
            foreach (var user in users)
            {
                var userCheck = _userManager.FindByEmailAsync(user.Email).Result;
                if (userCheck == null)
                {
                    var newUser = new CinemaUser
                    {
                        FirstName = user.Email,
                        LastName = user.Email,
                        UserName = user.Email,
                        NormalizedUserName = user.Email,
                        Email = user.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        Age = 21,
                        ShoppingCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(newUser, user.Password).Result;
                    status = status && result.Succeeded;
                    await _userManager.AddToRoleAsync(newUser, user.Role);
                }

            }
            return status;
        }
    }
}
