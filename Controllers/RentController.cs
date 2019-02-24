using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class RentController : Controller
    {
        private readonly ApplicationContext _context;

        public RentController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var rents = _context.Rents
                .Include(r => r.Client)
                .Include(r => r.Status)
                .Include(r => r.Vehicle)
                .Include(r => r.Employee)
                .ToList();

            return View(rents);
        }

        public IActionResult Delete(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
                return NotFound();

            _context.Rents.Remove(rent);

            _context.SaveChanges();

            return RedirectToAction("Index", "Rent");
        }

        public IActionResult Details(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
                return NotFound();

            var client = _context.Clients.SingleOrDefault(c => c.Id == rent.ClientId);
            rent.Client = client;

            var status = _context.Statuses.SingleOrDefault(s => s.Id == rent.StatusId);
            rent.Status = status;

            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == rent.VehicleId);
            rent.Vehicle = vehicle;

            var employee = _context.Employees.SingleOrDefault(e => e.Id == rent.EmployeeId);
            rent.Employee = employee;

            return View(rent);
        }

        public IActionResult New()
        {
            var viewModel = new RentViewModel(new Rent())
            {
                Statuses = _context.Statuses.ToList(),
                Clients = _context.Clients.ToList(),
                Vehicles = _context.Vehicles.ToList(),
                Employees = _context.Employees.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RentViewModel(rent)
                {
                    Statuses = _context.Statuses.ToList(),
                    Clients = _context.Clients.ToList(),
                    Vehicles = _context.Vehicles.ToList(),
                    Employees = _context.Employees.ToList()
                };

                return View("New", viewModel);
            }

            if (rent.Id == 0)
            {
                var client = _context.Clients.SingleOrDefault(c => c.Id == rent.ClientId);
                rent.Client = client;

                var status = _context.Statuses.SingleOrDefault(s => s.Id == rent.StatusId);
                rent.Status = status;

                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == rent.VehicleId);
                vehicle.IsRented = true;
                rent.Vehicle = vehicle;

                var employee = _context.Employees.SingleOrDefault(e => e.Id == rent.EmployeeId);
                rent.Employee = employee;

                _context.Rents.Add(rent);
            }
            else
            {
                var rentInDb = _context.Rents.SingleOrDefault(r => r.Id == rent.Id);

                var client = _context.Clients.SingleOrDefault(c => c.Id == rent.ClientId);
                rentInDb.Client = client;
                rentInDb.ClientId = rent.ClientId;

                var status = _context.Statuses.SingleOrDefault(s => s.Id == rent.StatusId);
                rentInDb.Status = status;
                rentInDb.StatusId = rent.StatusId;

                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == rent.VehicleId);
                rentInDb.Vehicle = vehicle;
                rentInDb.VehicleId = rent.VehicleId;

                var employee = _context.Employees.SingleOrDefault(e => e.Id == rent.EmployeeId);
                rentInDb.Employee = employee;
                rentInDb.EmployeeId = rent.EmployeeId;

                rentInDb.RentDate = rent.RentDate;
                rentInDb.ReturnDate = rent.ReturnDate;
                rentInDb.PricePerDay = rent.PricePerDay;
                rentInDb.NumberOfDays = rent.NumberOfDays;
                rentInDb.Comment = rent.Comment;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Rent");
        }

        public IActionResult Edit(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
                return NotFound();

            var viewModel = new RentViewModel(rent)
            {
                Statuses = _context.Statuses.ToList(),
                Clients = _context.Clients.ToList(),
                Vehicles = _context.Vehicles.ToList(),
                Employees = _context.Employees.ToList()
            };

            return View("New", viewModel);
        }
    }
}