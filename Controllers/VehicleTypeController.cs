using Microsoft.AspNetCore.Mvc;

namespace RentCar.Controllers
{
    public class VehicleTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}