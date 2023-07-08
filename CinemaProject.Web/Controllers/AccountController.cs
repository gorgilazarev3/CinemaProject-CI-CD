using CinemaProject.Domain.DTO;
using CinemaProject.Domain.Identity;
using CinemaProject.Domain.ViewModels;
using CinemaProject.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaProject.Web.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<CinemaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        

        public AccountController(IUserRepository userRepository, UserManager<CinemaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> UserRoles()
        {
            var allUsers = _userRepository.GetAll();
            var userModels = new List<UserRoleDTO>();
            foreach (var user in allUsers)
            {
                var role = "";
                if(await _userManager.IsInRoleAsync(user, "STANDARD_USER"))
                {
                    role = "STANDARD_USER";
                }
                if (await _userManager.IsInRoleAsync(user, "ADMIN"))
                {
                    role = "ADMIN";
                }
                userModels.Add(new UserRoleDTO
                {
                    User = user,
                    CurrentRole = role,
                    SelectedRole = role
                });
            }
            var allRoles = _roleManager.Roles;
            var model = new UserRolesDTO
            {
                AllRoles = allRoles,
                AllUsers = userModels,
                SelectedRole = "STANDARD_USER"
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>  ChangeUserRole(string user, string role)
        {
            var cinemaUser = await _userManager.FindByEmailAsync(user);
            await _userManager.RemoveFromRolesAsync(cinemaUser, _roleManager.Roles.Select(r => r.Name));
            await _userManager.AddToRoleAsync(cinemaUser, role);
            return RedirectToAction("UserRoles");
        }

        [HttpPost]
        public IActionResult UserRolePage(string user, string currentRole)
        {
            var allRoles = _roleManager.Roles;
            var model = new ChangeUserRoleDTO
            {
                CurrentRole = currentRole,
                UserId = user,
                AllRoles = allRoles,
                SelectedRole = currentRole
            };
            return View(model);
        }
    }
}
