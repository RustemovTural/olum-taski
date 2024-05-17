
using bilet_3.DAL;
using bilet_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bilet_3.Controllers
{
    public class HomeController : Controller
    {
      AppDbContext _db;

        public HomeController(AppDbContext dbcontext)
        {
            _db = dbcontext;
        }

        public IActionResult Index()
        {
            List<Doctor>doctors = _db.Doctors.ToList();

            return View(doctors);
        }

      
    }
}
