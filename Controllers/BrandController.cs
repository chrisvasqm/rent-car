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


        public IActionResult Details(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);
            var status = _context.Statuses.SingleOrDefault(b => b.Id == id);
            
            if (brand == null || status == null)
                return NotFound();

            brand.Status = status;
            
            return View(brand);
        }

        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);

            _context.SaveChanges();

            return RedirectToAction("Index", "Brand");
        }
    }
}