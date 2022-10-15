using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Shop.Helpers;
using System.Text.Json;

namespace MVC_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly TechShopDbContext context;

        public CartController(TechShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) ids = new List<int>();

            List<Laptop?> laptops = ids.Select(id => context.Laptops.Find(id)).ToList();

            return View(laptops);
        }

        public IActionResult Add(int id)
        {
            if (context.Laptops.Find(id) == null) return NotFound();

            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");

            if (ids == null) ids = new List<int>();

            ids.Add(id);

            HttpContext.Session.SetObject("cartKey", ids);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");

            if (ids == null) return NotFound();

            ids.Remove(id);

            HttpContext.Session.SetObject("cartKey", ids);

            return RedirectToAction("Index", "Home");
        }
    }
}
