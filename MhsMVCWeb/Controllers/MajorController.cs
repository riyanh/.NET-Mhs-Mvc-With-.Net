using MhsMVCWeb.Data;
using MhsMVCWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MhsMVCWeb.Controllers
{
    public class MajorController : Controller
    {
        private readonly AppDbContext _db;

        public MajorController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Major> objMajor = _db.Majors;
            return View(objMajor);
        }
    }
}
