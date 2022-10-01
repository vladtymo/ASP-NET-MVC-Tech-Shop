using Microsoft.AspNetCore.Mvc;
using MVC_Tech_Shop.Data;
using MVC_Tech_Shop.Models;
using System.Diagnostics;

namespace MVC_Tech_Shop.Controllers
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