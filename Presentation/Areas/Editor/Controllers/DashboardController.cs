using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Editor.Controllers
{
    [Area("Editor")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
