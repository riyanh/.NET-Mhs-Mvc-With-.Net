using MhsMVCWeb.Data;
using MhsMVCWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MhsMVCWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudent = _db.Students;
            return View(objStudent);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (obj.Name == obj.Adress)
            {
                ModelState.AddModelError("CustomError", "The Address cannot exacly match The name");
            }
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _db.Students.Find(id);
            //var studentToDbFirst = _db.Students.FirstOrDefault(u => u.Id == id);
            //var studentToDbSingle = _db.Students.SingleOrDefault(u => u.Id == id);
            if(studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (obj.Name == obj.Adress)
            {
                ModelState.AddModelError("CustomError", "The Address cannot exacly match The name");
            }
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _db.Students.Find(id);
            //var studentToDbFirst = _db.Students.FirstOrDefault(u => u.Id == id);
            //var studentToDbSingle = _db.Students.SingleOrDefault(u => u.Id == id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //POST EDIT
        //[HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Students.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
