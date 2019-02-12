using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.Views.Model;

namespace RentCar.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        
        public EmployeeController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.Status)
                .Include(e => e.WorkShift)
                .Include(e => e.Commission)
                .ToList();

            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            var status = _context.Statuses.SingleOrDefault(s => s.Id == employee.StatusId);
            employee.Status = status;

            var commission = _context.Commissions.SingleOrDefault(c => c.Id == employee.CommissionId);
            employee.Commission = commission;

            var workShift = _context.WorkShifts.SingleOrDefault(w => w.Id == employee.WorkShiftId);
            employee.WorkShift = workShift;

            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);

            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult New()
        {
            var viewModel = new EmployeeViewModel(new Employee())
            {
                Statuses = _context.Statuses.ToList(),
                Commissions = _context.Commissions.ToList(),
                WorkShifts = _context.WorkShifts.ToList()
            };

            return View(viewModel);
        }
    }
}