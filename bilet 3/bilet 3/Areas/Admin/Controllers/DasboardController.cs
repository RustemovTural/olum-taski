using Microsoft.AspNetCore.Mvc;

namespace bilet_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DasboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
