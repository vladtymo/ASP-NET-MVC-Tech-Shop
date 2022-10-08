using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Data;
using MVC_Shop.Models;

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
            var laptops = context.Laptops.ToList();

            return View(laptops);
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