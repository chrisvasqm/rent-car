using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Clauses.ResultOperators;
using RentCar.Models;
using RentCar.Views.Model;
using Model = Microsoft.EntityFrameworkCore.Metadata.Internal.Model;

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

        [Route("employees/save")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeViewModel(new Employee())
                {
                    Statuses = _context.Statuses.ToList(),
                    Commissions = _context.Commissions.ToList(),
                    WorkShifts = _context.WorkShifts.ToList()
                };

                return View("New", viewModel);
            }

            if (employee.Id == 0)
            {
                // If it is a new employee, add it to the DB
                var status = _context.Statuses.SingleOrDefault(s => s.Id == employee.StatusId);
                employee.Status = status;

                var commission = _context.Commissions.SingleOrDefault(c => c.Id == employee.CommissionId);
                employee.Commission = commission;

                var workShift = _context.WorkShifts.SingleOrDefault(w => w.Id == employee.WorkShiftId);
                employee.WorkShift = workShift;

                _context.Employees.Add(employee);
            }
            else
            {
                // If it is already in the DB, replace all it's properties for the new ones
                var employeeInDb = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);

                if (employeeInDb == null)
                    return NotFound();

                employeeInDb.Name = employee.Name;
                employeeInDb.StatusId = employee.StatusId;
                employeeInDb.Status = employee.Status;
                employeeInDb.CommissionId = employee.CommissionId;
                employeeInDb.Commission = employee.Commission;
                employeeInDb.WorkShiftId = employee.WorkShiftId;
                employeeInDb.WorkShift = employee.WorkShift;
                employeeInDb.AdmissionDate = employee.AdmissionDate;
                employeeInDb.IdentificationCard = employee.IdentificationCard;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();
            
            var viewModel = new EmployeeViewModel(employee)
            {
                Statuses = _context.Statuses.ToList(),
                Commissions = _context.Commissions.ToList(),
                WorkShifts = _context.WorkShifts.ToList()
            };

            return View("New", viewModel);
        }
    }
}