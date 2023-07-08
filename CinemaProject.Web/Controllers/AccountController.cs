using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult UserRoles()
        {
            return View();
        }
    }
}
