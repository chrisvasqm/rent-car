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
    }
}