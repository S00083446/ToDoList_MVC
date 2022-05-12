  using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess;
using ToDoListModels;

namespace ToDoListWeb.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Subjects> objSubjectList = _db.Subjects;

            return View(objSubjectList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Subjects obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

            }
            if (ModelState.IsValid)
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Subject created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Subjects.Find(id);
            var categoryFromDbFirst = _db.Subjects.FirstOrDefault(u => u.Name == "id");
            //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Subjects obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");

            }
            if (ModelState.IsValid)
            {
                _db.Subjects.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Subject updated successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Subjects.Find(id);
            //var categoryFromDbFirst = _db.Subjects.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Subjects.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
                _db.Subjects.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Subject deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

   

