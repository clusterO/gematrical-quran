using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
