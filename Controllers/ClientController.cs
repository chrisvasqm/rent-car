using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.ViewModel;

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
        
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound();

            _context.Remove(client);

            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }

        public IActionResult Details(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound();

            var status = _context.Statuses.SingleOrDefault(s => s.Id == client.StatusId);
            client.Status = status;

            var personType = _context.PersonTypes.SingleOrDefault(p => p.Id == client.PersonTypeId);
            client.PersonType = personType;

            return View(client);
        }
    }
}