using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationContext _context;
        
        public VehicleController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();
            
            return View(vehicles);
        }

        public IActionResult New()
        {
            var viewModel = new VehicleViewModel(new Vehicle())
            {
                Statuses = _context.Statuses.ToList()
            };
            
            return View(viewModel);
        }
    }
}