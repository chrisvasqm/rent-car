using Microsoft.AspNetCore.Mvc;

namespace RentCar.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}