using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_Shop.Controllers
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
            var laptops = context.Laptops.Include(l => l.OperationSystem).ToList(); //MockData.GetLaptops();

            return View(laptops); // Views/Laptops/Index.cshtml
        }

        // GET: /Laptops/Details/{id}
        public IActionResult Details(int id)
        {
            Laptop? laptop = context.Laptops.Find(id); //MockData.GetLaptopById(id);

            if (laptop == null) return NotFound();

            //ViewData - Type Conversion code is required while enumerating
            //ViewData["ReturnUrl"] = Request.Headers["Referer"].ToString();

            // ViewBag - used dynamic, so there is no need to type conversion while enumerating
            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();

            return View(laptop); // Views/Laptops/Details.cshtml
        }

        // GET: /Laptops/Create
        [HttpGet] // by default
        public IActionResult Create()
        {
            SetOperationSystems();

            return View();
        }

        private void SetOperationSystems()
        {
            var osList = context.OperationSystems.ToList();
            ViewBag.OSList = new SelectList(osList, nameof(OperationSystem.Id), nameof(OperationSystem.Name));
        }

        // POST: /Laptops/Create
        [HttpPost]
        public IActionResult Create(Laptop laptop)
        {
            if (!ModelState.IsValid)
            {
                SetOperationSystems();
                return View(laptop);
            }

            context.Laptops.Add(laptop);
            context.SaveChanges();

            TempData["alertMessage"] = "Product was successfully created!";

            return RedirectToAction(nameof(Index));
        }

        // GET: /Laptops/Edit/{id}
        public IActionResult Edit(int id)
        {
            // TODO: add validation
            Laptop? laptop = context.Laptops.Find(id);

            if (laptop == null) return NotFound();

            SetOperationSystems();

            return View(laptop);
        }

        // POST: /Laptops/Edit
        [HttpPost]
        public IActionResult Edit(Laptop laptop)
        {
            if (!ModelState.IsValid)
            {
                SetOperationSystems();
                return View(laptop);
            }

            context.Laptops.Update(laptop);
            context.SaveChanges();

            // show toastr
            TempData["alertMessage"] = "Product was successfully edited!";

            return RedirectToAction(nameof(Index));
        }

        // GET: /Laptops/Delete/{id}
        public IActionResult Delete(int id)
        {
            Laptop? laptop = context.Laptops.Find(id);

            if (laptop == null) return NotFound();

            context.Laptops.Remove(laptop);
            context.SaveChanges();

            // show toastr
            TempData["alertMessage"] = "Product was successfully deleted!";

            return RedirectToAction(nameof(Index));
        }
    }
}
