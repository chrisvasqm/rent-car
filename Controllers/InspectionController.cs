using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.ViewModel;

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

        public IActionResult Delete(int id)
        {
            var inspection = _context.Inspections.SingleOrDefault(i => i.Id == id);

            if (inspection == null)
                return NotFound();

            _context.Inspections.Remove(inspection);

            _context.SaveChanges();

            return RedirectToAction("Index", "Inspection");
        }

        
        public IActionResult New()
        {
            var viewModel = new InspectionViewModel(new Inspection())
            {
                Statuses = _context.Statuses.ToList(),
                Employees = _context.Employees.ToList(),
                Clients = _context.Clients.ToList(),
                Vehicles = _context.Vehicles.ToList(),
                FuelAmountses = _context.FuelAmountses.ToList()
            };

            return View(viewModel);
        }
    }
}