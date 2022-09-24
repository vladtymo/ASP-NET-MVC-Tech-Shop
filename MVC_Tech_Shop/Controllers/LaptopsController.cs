using Microsoft.AspNetCore.Mvc;
using MVC_Tech_Shop.Data;
using MVC_Tech_Shop.Models;

namespace MVC_Tech_Shop.Controllers
{
    public class LaptopsController : Controller
    {
        public IActionResult Index()
        {
            var laptops = MockData.GetLaptops();

            return View(laptops); // Views/Laptops/Index.cshtml
        }

        public IActionResult Details(int id)
        {
            Laptop laptop = MockData.GetLaptopById(id);

            return View(laptop); // Views/Laptops/Details.cshtml
        }
    }
}
