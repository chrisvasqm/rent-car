using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly ApplicationContext _context;

        public VehicleTypeController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var model = _context.VehicleTypes
                .Include(m => m.Status)
                .ToList();

            return View(model);
        }
    }
}