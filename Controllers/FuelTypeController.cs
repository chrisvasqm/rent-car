using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class FuelTypeController : Controller
    {
        private readonly ApplicationContext _context;

        public FuelTypeController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            var fuelTypes = _context.FuelTypes
                .Include(f => f.Status)
                .ToList();

            return View(fuelTypes);
        }
    }
}