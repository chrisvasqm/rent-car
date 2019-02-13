using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationContext _context;

        public ClientController()
        {
            _context = new ApplicationContext();
        }

        public IActionResult Index()
        {
            var clients = _context.Clients
                .Include(c => c.Status)
                .Include(c => c.PersonType)
                .ToList();

            return View(clients);
        }
    }
}