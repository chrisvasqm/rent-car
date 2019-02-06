using Microsoft.AspNetCore.Mvc;

namespace RentCar.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}