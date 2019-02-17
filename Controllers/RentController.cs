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
    }
}