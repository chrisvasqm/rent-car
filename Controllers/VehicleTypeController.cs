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
                var status = _context.Statuses.Single(m => m.Id == vehicleType.StatusId);
                vehicleType.Status = status;
                _context.VehicleTypes.Add(vehicleType);
            }
            else
            {
                var vehicleTypeInDb = _context.VehicleTypes.Single(vt => vt.Id == vehicleType.Id);

                vehicleTypeInDb.Description = vehicleType.Description;
                vehicleTypeInDb.StatusId = vehicleType.StatusId;                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "VehicleType");
        }
    }
}