using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class InspectionController : Controller
    {
        private readonly ApplicationContext _context;

        public InspectionController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var inspections = _context.Inspections
                .Include(i => i.Vehicle)
                .Include(i => i.Client)
                .Include(i => i.Status)
                .Include(i => i.FuelAmount)
                .ToList();
            
            return View(inspections);
        }
    }
}