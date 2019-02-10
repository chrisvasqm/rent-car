using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("vehicles/")]
        public IActionResult Index()
        {
            var vehicles = _context.Vehicles
                .Include(v => v.Status)
                .ToList();
            
            return View(vehicles);
        }

        [Route("vehicles/new")]
        public IActionResult New()
        {
            var viewModel = new VehicleViewModel(new Vehicle())
            {
                Statuses = _context.Statuses.ToList()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [Route("vehicles/save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Vehicle vehicle)
        {
            // Show an error message if the state of the model is invalid.
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleViewModel(new Vehicle())
                {
                    Statuses = _context.Statuses.ToList()
                };

                return View("New", viewModel);
            }

            if (vehicle.Id == 0)
            {
                // Adding a new item
                var status = _context.Statuses.SingleOrDefault(s => s.Id == vehicle.StatusId);
                vehicle.Status = status;
                _context.Vehicles.Add(vehicle);
            }
            else
            {
                // Editing an existing one
                var vehicleInDb = _context.Vehicles.SingleOrDefault(v => v.Id == vehicle.Id);

                if (vehicleInDb == null)
                    return NotFound();

                vehicleInDb.Description = vehicle.Description;
                vehicleInDb.StatusId = vehicle.StatusId;

                var status = _context.Statuses.SingleOrDefault(s => s.Id == vehicleInDb.StatusId);

                vehicleInDb.Status = status;
            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Vehicle");
        }

        [Route("vehicles/details/{id}")]
        public IActionResult Details(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var status = _context.Statuses.SingleOrDefault(s => s.Id == vehicle.StatusId);

            vehicle.Status = status;

            return View(vehicle);
        }

        [Route("vehicles/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var viewModel = new VehicleViewModel(vehicle)
            {
                Statuses = _context.Statuses.ToList()
            };

            return View("New", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            _context.Vehicles.Remove(vehicle);

            _context.SaveChanges();

            return RedirectToAction("Index", "Vehicle");
        }
    }
}