using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Shop.Helpers;
using System.Security.Claims;

namespace MVC_Tech_Shop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly TechShopDbContext context;

        public OrdersController(TechShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = context.Orders.Where(o => o.UserId == userId);

            return View(orders);
        }

        public async Task<IActionResult> Add()
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) return BadRequest();

            List<Laptop?> laptops = ids.Select(id => context.Laptops.Find(id)).ToList();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Order newOrder = new Order()
            {
                Date = DateTime.Now,
                TotalPrice = laptops.Sum(x => x.Price),
                UserId = userId
            };

            context.Orders.Add(newOrder);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
