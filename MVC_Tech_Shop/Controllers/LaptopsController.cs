using Microsoft.AspNetCore.Mvc;
using MVC_Tech_Shop.Data;
using MVC_Tech_Shop.Models;

namespace MVC_Tech_Shop.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly TechShopDbContext context;

        public LaptopsController(TechShopDbContext context)
        {
            this.context = context;
        }

        // GET: /Laptops/Index
        public IActionResult Index()
        {
            var laptops = context.Laptops.ToList(); //MockData.GetLaptops();

            return View(laptops); // Views/Laptops/Index.cshtml
        }

        // GET: /Laptops/Details/{id}
        public IActionResult Details(int id)
        {
            Laptop? laptop = context.Laptops.Find(id); //MockData.GetLaptopById(id);

            if (laptop == null) return NotFound(); 

            return View(laptop); // Views/Laptops/Details.cshtml
        }

        // GET: /Laptops/Create
        [HttpGet] // by default
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Laptops/Create
        [HttpPost]
        public IActionResult Create(Laptop laptop)
        {
            if (!ModelState.IsValid) return View(laptop);

            context.Laptops.Add(laptop);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
