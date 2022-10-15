using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Data;
using MVC_Shop.Models;
using MVC_Shop.ViewModels;
using MVC_Shop.Helpers;

namespace MVC_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly TechShopDbContext context;

        public HomeController(TechShopDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var laptops = context.Laptops.Select(l => new LaptopCardViewModel()
            {
                Laptop = l,
            }).ToList();

            foreach (var item in laptops)
            {
                item.IsInCart = IsProductInCart(item.Laptop.Id);
            }

            return View(laptops);
        }

        private bool IsProductInCart(int id)
        {
            List<int>? ids = HttpContext.Session.GetObject<List<int>>("cartKey");
            if (ids == null) return false;

            return ids.Contains(id);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}