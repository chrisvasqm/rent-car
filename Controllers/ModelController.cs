using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationContext _context;

        public ModelController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var models = _context.Models
                .Include(m => m.Status)
                .ToList();

            return View(models);
        }
    }
}