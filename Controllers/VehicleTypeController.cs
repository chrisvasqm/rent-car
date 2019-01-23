using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
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

        [Route("vehicle-types/new")]
        public IActionResult New()
        {
            var viewModel = new VehicleTypeViewModel(new VehicleType())
            {
                Statuses = _context.Statuses.ToList()
            };

            return View("VehicleForm", viewModel);
        }

        [HttpPost]
        [Route("vehicle-types/save")]
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

        [Route("vehicle-types/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);

            if (vehicleType == null)
                return NotFound();

            var viewModel = new VehicleTypeViewModel(vehicleType)
            {
                Statuses = _context.Statuses.ToList(),
            };

            return View("VehicleForm", viewModel);
        }

        [Route("vehicle-types/details/{id}")]
        public IActionResult Details(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);
            var status = _context.Statuses.SingleOrDefault(s => s.Id == vehicleType.StatusId);

            if (vehicleType == null || status == null)
                return NotFound();

            vehicleType.Status = status;
            
            return View(vehicleType);
        }
        
        [Route("vehicle-types/delete/{id}")]

        public IActionResult Delete(int id)
        {
            var vehicleType = _context.VehicleTypes.SingleOrDefault(vt => vt.Id == id);

            if (vehicleType == null)
                return NotFound();

            _context.VehicleTypes.Remove(vehicleType);

            _context.SaveChanges();

            return RedirectToAction("Index", "VehicleType");
        }
    }
}