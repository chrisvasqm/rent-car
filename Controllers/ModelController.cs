using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.ViewModel;

namespace RentCar.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationContext _context;

        public ModelController()
        {
            _context = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var models = _context.Models
                .Include(m => m.Status)
                .ToList();

            return View(models);
        }

        public IActionResult New()
        {
            var viewModel = new ModelViewModel(new Model())
            {
                Statuses = _context.Statuses.ToList()
            };

            return View("ModelForm", viewModel);
        }

        public IActionResult Save(Model model)
        {
            // Show an error message if the state of the model is invalid.
            if (!ModelState.IsValid)
            {
                var viewModel = new ModelViewModel(model)
                {
                    Statuses = _context.Statuses.ToList()
                };

                return View("ModelForm", viewModel);
            }


            if (model.Id == 0)
            {
                // Adding a new item
                var status = _context.Statuses.Single(m => m.Id == model.StatusId);
                model.Status = status;
                _context.Models.Add(model);
            }
            else
            {
                // Editing an existing one
                var brandInDb = _context.Models.Single(b => b.Id == model.Id);

                brandInDb.Description = model.Description;
                brandInDb.StatusId = model.StatusId;

                var status = _context.Statuses.Single(b => b.Id == brandInDb.StatusId);
                brandInDb.Status = status;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Model");
        }
    }
}