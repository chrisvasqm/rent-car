using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

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
    }
}