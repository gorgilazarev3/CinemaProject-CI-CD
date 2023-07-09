using CinemaProject.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using CinemaProject.Domain.DomainModels;
using System.Threading.Tasks;
using CinemaProject.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace CinemaProject.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ShoppingCart model = _shoppingCartService.GetShoppingCartForUser(userId);
            return View(model);
        }

        public IActionResult RemoveTicketFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.RemoveTicketFromShoppingCart(userId, id);
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(Guid? ticketId)
        {
            if (ticketId == null)
            {
                return NotFound();
            }
            AddTicketToCartDTO model = _shoppingCartService.AddTicketToShoppingCartPage(ticketId ?? new Guid());
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart(AddTicketToCartDTO model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserId = userId;
            _shoppingCartService.AddTicketToShoppingCart(model);
            return RedirectToAction("Index");
        }

        public IActionResult CheckoutOrder()
        {
            OrderNow();
            return RedirectToAction("Index");
        }

        //public IActionResult CheckoutOrder(string stripeEmail, string stripeToken)
        //{
        //    CustomerService customerService = new CustomerService();
        //    Customer customer = customerService.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Source = stripeToken
        //    });
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var order = _shoppingCartService.GetShoppingCartForUser(userId);

        //    ChargeService chargeService = new ChargeService();
        //    Charge charge = chargeService.Create(new ChargeCreateOptions
        //    {
        //        Customer = customer.Id,
        //        Currency = "usd",
        //        Amount = Convert.ToInt32(order.TotalPrice) * 100,
        //        Description = "Payment of order for E-Shop Integrated Systems App"
        //    });

        //    if (charge.Status == "succeeded")
        //    {
        //        var isOrderCreated = OrderNow();
        //    }
        //    return RedirectToAction("Index");
        //}

        private bool OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _shoppingCartService.CreateOrder(userId);
            return order != null;

        }
    }
}
