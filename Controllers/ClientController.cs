using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.ViewModel;
using RentCar.Views.Model;

namespace RentCar.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationContext _context;

        public ClientController()
        {
            _context = new ApplicationContext();
        }

        [Route("clients/")]
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

        [Route("clients/details/{id}")]
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

        [Route("clients/new")]
        public IActionResult New()
        {
            var viewModel = new ClientViewModel(new Client())

            {
                Statuses = _context.Statuses.ToList(),
                PersonTypes = _context.PersonTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("clients/save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Client client)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClientViewModel(new Client())
                {
                    Statuses = _context.Statuses.ToList(),
                    PersonTypes = _context.PersonTypes.ToList()
                };

                return View("New", viewModel);
            }

            if (client.Id == 0)
            {
                var status = _context.Statuses.SingleOrDefault(s => s.Id == client.StatusId);
                client.Status = status;

                var personType = _context.PersonTypes.SingleOrDefault(p => p.Id == client.PersonTypeId);
                client.PersonType = personType;

                _context.Clients.Add(client);
            }
            else
            {
                var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == client.Id);

                if (clientInDb == null)
                    return NotFound();

                clientInDb.Name = client.Name;
                clientInDb.Status = _context.Statuses.SingleOrDefault(s => s.Id == client.StatusId);
                clientInDb.StatusId = client.StatusId;
                clientInDb.PersonType = _context.PersonTypes.SingleOrDefault(p => p.Id == client.PersonTypeId);
                clientInDb.PersonTypeId = client.PersonTypeId;
                clientInDb.IdentificationCard = client.IdentificationCard;
                clientInDb.CreditCard = client.CreditCard;
                clientInDb.CreditLimit = client.CreditLimit;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Client");
        }
    }
}