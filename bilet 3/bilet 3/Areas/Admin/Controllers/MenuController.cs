using bilet_3.DAL;
using bilet_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bilet_3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Doctors.ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Manage\";
            string fileName = Guid.NewGuid() + doctor.ImageFile.FileName;
            string fullPath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                doctor.ImageFile.CopyTo(stream);
            }
            doctor.ImageUrl = fileName;

            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var existingItem = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (existingItem != null)
            {
                _context.Remove(existingItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existingItem = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            return View(existingItem);
        }

        [HttpPost]

        public IActionResult Update(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            if(doctor!= null)
            {
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Manage\";
                string fileName = Guid.NewGuid() + doctor.ImageFile.FileName;
                string fullPath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    doctor.ImageFile.CopyTo(stream);
                }
                doctor.ImageUrl = fileName;
            }
            _context.Update(doctor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
