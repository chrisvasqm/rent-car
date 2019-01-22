using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.ViewModel;

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

        [Route("vehicle-type/new")]
        public IActionResult New()
        {
            var viewModel = new VehicleTypeViewModel(new VehicleType())
            {
                Statuses = _context.Statuses.ToList()
            };

            return View("VehicleForm", viewModel);
        }

        [HttpPost]
        [Route("vehicle-type/save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(VehicleType vehicleType)
        {
            // Show an error message if the state of the model is invalid.
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleTypeViewModel(vehicleType)
                {
                    Statuses = _context.Statuses.ToList()
                };

                return View("VehicleForm", viewModel);
            }

            
            if (vehicleType.Id == 0)
            {
                // Adding a new item
                var status = _context.Statuses.Single(m => m.Id == vehicleType.StatusId);
                vehicleType.Status = status;
                _context.VehicleTypes.Add(vehicleType);
            }
            else
            {
                // Editing an existing one
                var vehicleTypeInDb = _context.VehicleTypes.Single(vt => vt.Id == vehicleType.Id);

                vehicleTypeInDb.Description = vehicleType.Description;
                vehicleTypeInDb.StatusId = vehicleType.StatusId;

                var status = _context.Statuses.Single(vt => vt.Id == vehicleTypeInDb.StatusId);
                vehicleTypeInDb.Status = status;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "VehicleType");
        }

        [Route("vehicle-type/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var model = _context.VehicleTypes.SingleOrDefault(m => m.Id == id);

            if (model == null)
                return NotFound();

            var viewModel = new VehicleTypeViewModel(model)
            {
                Statuses = _context.Statuses.ToList(),
            };

            return View("VehicleForm", viewModel);
        }
    }
}