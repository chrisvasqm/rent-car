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
    }
}