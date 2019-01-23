using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApplicationContext _context;

        public BrandController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var brands = _context.Brands
                .Include(b => b.Status)
                .ToList();
            
            return View(brands);
        }


        [Route("brands/details/{id}")]
        public IActionResult Details(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);
            var status = _context.Statuses.SingleOrDefault(b => b.Id == id);
            
            if (brand == null || status == null)
                return NotFound();

            brand.Status = status;
            
            return View(brand);
        }

        [Route("brands/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);

            _context.SaveChanges();

            return RedirectToAction("Index", "Brand");
        }

        [Route("brands/new")]
        public IActionResult New()
        {
            var viewModel = new BrandViewModel(new Brand())
            {
                Statuses = _context.Statuses.ToList()
            };

            return View("BrandForm", viewModel);
        }

        [HttpPost]
        [Route("brands/save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Brand brand)
        {
            // Show an error message if the state of the model is invalid.
            if (!ModelState.IsValid)
            {
                var viewModel = new BrandViewModel(brand)
                {
                    Statuses = _context.Statuses.ToList()
                };

                return View("BrandForm", viewModel);
            }

            
            if (brand.Id == 0)
            {
                // Adding a new item
                var status = _context.Statuses.Single(m => m.Id == brand.StatusId);
                brand.Status = status;
                _context.Brands.Add(brand);
            }
            else
            {
                // Editing an existing one
                var brandInDb = _context.Brands.Single(b => b.Id == brand.Id);

                brandInDb.Description = brand.Description;
                brandInDb.StatusId = brand.StatusId;

                var status = _context.Statuses.Single(b => b.Id == brandInDb.StatusId);
                brandInDb.Status = status;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Brand");
        }

        [Route("brands/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brand == null)
                return NotFound();

            var viewModel = new BrandViewModel(brand)
            {
                Statuses = _context.Statuses.ToList(),
            };

            return View("BrandForm", viewModel);
        }
    }
}