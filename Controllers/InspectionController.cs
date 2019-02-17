using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
                .Include(i => i.Employee)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new InspectionViewModel(new Inspection())
                {
                    Statuses = _context.Statuses.ToList(),
                    Employees = _context.Employees.ToList(),
                    Clients = _context.Clients.ToList(),
                    Vehicles = _context.Vehicles.ToList(),
                    FuelAmountses = _context.FuelAmountses.ToList()
                };

                return View("New", viewModel);
            }

            if (inspection.Id == 0)
            {
                var status = _context.Statuses.SingleOrDefault(s => s.Id == inspection.StatusId);
                inspection.Status = status;

                var employee = _context.Employees.SingleOrDefault(e => e.Id == inspection.EmployeeId);
                inspection.Employee = employee;

                var client = _context.Clients.SingleOrDefault(c => c.Id == inspection.ClientId);
                inspection.Client = client;

                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == inspection.VehicleId);
                inspection.Vehicle = vehicle;

                var fuelAmount = _context.FuelAmountses.SingleOrDefault(f => f.Id == inspection.FuelAmountId);
                inspection.FuelAmount = fuelAmount;

                _context.Inspections.Add(inspection);
            }
            else
            {
                var inspectionInDb = _context.Inspections.SingleOrDefault(i => i.Id == inspection.Id);

                inspectionInDb.StatusId = inspection.StatusId;
                var status = _context.Statuses.SingleOrDefault(s => s.Id == inspection.StatusId);
                inspectionInDb.Status = status;

                inspectionInDb.EmployeeId = inspection.EmployeeId;
                var employee = _context.Employees.SingleOrDefault(e => e.Id == inspection.EmployeeId);
                inspectionInDb.Employee = employee;

                inspectionInDb.ClientId = inspection.ClientId;
                var client = _context.Clients.SingleOrDefault(c => c.Id == inspection.ClientId);
                inspectionInDb.Client = client;

                inspectionInDb.VehicleId = inspection.VehicleId;
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == inspection.VehicleId);
                vehicle.IsRented = true;
                inspectionInDb.Vehicle = vehicle;

                inspectionInDb.FuelAmountId = inspection.FuelAmountId;
                var fuelAmount = _context.FuelAmountses.SingleOrDefault(f => f.Id == inspection.FuelAmountId);
                inspectionInDb.FuelAmount = fuelAmount;

                inspectionInDb.CreatedAt = inspection.CreatedAt;

                inspectionInDb.HasScratches = inspection.HasScratches;

                inspectionInDb.HasCatJack = inspection.HasCatJack;

                inspectionInDb.HasBrokenGlass = inspection.HasBrokenGlass;

                inspectionInDb.HasReplacementTire = inspection.HasReplacementTire;

                inspectionInDb.IsFirstTireGood = inspection.IsFirstTireGood;

                inspectionInDb.IsSecondTireGood = inspection.IsSecondTireGood;

                inspectionInDb.IsThirdTireGood = inspection.IsThirdTireGood;

                inspectionInDb.IsFourthTireGood = inspection.IsFourthTireGood;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Inspection");
        }

        public IActionResult Edit(int id)
        {
            var inspection = _context.Inspections.SingleOrDefault(i => i.Id == id);

            if (inspection == null)
                return NotFound();
            
            var viewModel = new InspectionViewModel(inspection)
            {
                Statuses = _context.Statuses.ToList(),
                Employees = _context.Employees.ToList(),
                Clients = _context.Clients.ToList(),
                Vehicles = _context.Vehicles.ToList(),
                FuelAmountses = _context.FuelAmountses.ToList()
            };

            return View("New", viewModel);
        }

        public IActionResult Details(int id)
        {
            var inspection = _context.Inspections.SingleOrDefault(i => i.Id == id);

            if (inspection == null)
                return NotFound();
            
            var status = _context.Statuses.SingleOrDefault(s => s.Id == inspection.StatusId);
            inspection.Status = status;

            var employee = _context.Employees.SingleOrDefault(e => e.Id == inspection.EmployeeId);
            inspection.Employee = employee;

            var client = _context.Clients.SingleOrDefault(c => c.Id == inspection.ClientId);
            inspection.Client = client;

            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == inspection.VehicleId);
            inspection.Vehicle = vehicle;

            var fuelAmount = _context.FuelAmountses.SingleOrDefault(f => f.Id == inspection.FuelAmountId);
            inspection.FuelAmount = fuelAmount;

            return View(inspection);
        }
    }
}