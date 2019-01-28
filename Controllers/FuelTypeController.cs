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

        [Route("fuel-type/")]
        public IActionResult Index()
        {
            var fuelTypes = _context.FuelTypes
                .Include(f => f.Status)
                .ToList();

            return View(fuelTypes);
        }

        [Route("fuel-type/details/{id}")]
        public IActionResult Details(int id)
        {
            var fuelType = _context.FuelTypes.SingleOrDefault(ft => ft.Id == id);

            if (fuelType == null)
                return NotFound();

            var status = _context.Statuses.SingleOrDefault(s => s.Id == fuelType.StatusId);

            if (status == null)
                return NotFound();

            fuelType.Status = status;

            return View(fuelType);
        }

        [Route("fuel-type/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var fuelType = _context.FuelTypes.SingleOrDefault(ft => ft.Id == id);

            if (fuelType == null)
                return NotFound();

            _context.FuelTypes.Remove(fuelType);

            _context.SaveChanges();

            return RedirectToAction("Index", "FuelType");
        }

        [Route("fuel-type/new")]
        public IActionResult New()
        {
            var viewModel = new FuelTypeViewModel(new FuelType())
            {
                Statuses = _context.Statuses.ToList()
            };

            return View(viewModel);
        }
    }
}