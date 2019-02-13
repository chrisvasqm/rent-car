using Microsoft.AspNetCore.Mvc;

namespace RentCar.Controllers
{
    public class ManageController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}