using Microsoft.AspNetCore.Mvc;

namespace WebApp2ByChirag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
