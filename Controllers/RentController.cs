using Microsoft.AspNetCore.Mvc;
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
            
        }
    }
}