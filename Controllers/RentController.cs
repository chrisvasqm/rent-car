using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        public IActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EmployeeSortParam = sortOrder == "Employee" ? "employee_desc" : "Employee";
            ViewBag.ClientSortParam = sortOrder == "Client" ? "client_desc" : "Client";
            ViewBag.VehicleSortParam = sortOrder == "Vehicle" ? "vehicle_desc" : "Vehicle";
            ViewBag.StatusSortParam = sortOrder == "Status" ? "status_desc" : "Status";

            var rents = _context.Rents
                .Include(r => r.Client)
                .Include(r => r.Status)
                .Include(r => r.Vehicle)
                .Include(r => r.Employee)
                .AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    rents = rents.OrderByDescending(r => r.Id);
                    break;
                case "Date":
                    rents = rents.OrderBy(r => r.RentDate);
                    break;
                case "date_desc":
                    rents = rents.OrderByDescending(r => r.ReturnDate);
                    break;
                case "Employee":
                    rents = rents.OrderBy(r => r.Employee);
                    break;
                case "employee_desc":
                    rents = rents.OrderByDescending(r => r.Employee);
                    break;
                case "Client":
                    rents = rents.OrderBy(r => r.Client);
                    break;
                case "client_desc":
                    rents = rents.OrderByDescending(r => r.Client);
                    break;
                case "Vehicle":
                    rents = rents.OrderBy(r => r.Vehicle);
                    break;
                case "vehicle_desc":
                    rents = rents.OrderByDescending(r => r.Vehicle);
                    break;
                case "Status":
                    rents = rents.OrderBy(r => r.Status);
                    break;
                case "status_desc":
                    rents = rents.OrderByDescending(r => r.Status);
                    break;
                default:
                    rents = rents.OrderBy(s => s.Id);
                    break;
            }

            return View(rents.ToList());
        }

        public IActionResult Delete(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
                return NotFound();

            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == rent.VehicleId);
            rent.Vehicle = vehicle;
            rent.Vehicle.IsRented = false;

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
                Vehicles = _context.Vehicles.Where(v => v.IsRented == false).ToList(),
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

        public IActionResult ConfirmReturn(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
                return NotFound();

            return View(rent);
        }
    }
}