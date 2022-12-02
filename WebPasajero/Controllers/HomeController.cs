using Microsoft.AspNetCore.Mvc;

namespace WebPasajero.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
