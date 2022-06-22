using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;
using System.Collections.Generic;

namespace ToDoListWeb.Areas.Admin.Controllers;
[Area("Admin")]

//[Route("api/[controller]/Subject")]
//[ApiController]
public class SubjectController : Controller
{
    //private readonly ApplicationDbContext _db;
    private readonly IUnitOfWork _unitOfWork;

    public SubjectController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<Subjects> objSubjectList = _unitOfWork.Subjects.GetAll();

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
            _unitOfWork.Subjects.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Subject created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    // GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Subjects.Find(id);
        var subjectFromDbFirst = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

        if (subjectFromDbFirst == null)
        {
            return NotFound();
        }
        return View(subjectFromDbFirst);
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
            _unitOfWork.Subjects.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Subject updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    // GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        //var categoryFromDb = _db.Subjects.Find(id);

        //var categoryFromFirst = _db.FirstOrDefault(u => u.Id == id);
        var subjectFromDbFirst = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

        if (subjectFromDbFirst == null)
        {
            return NotFound();
        }
        return View(subjectFromDbFirst);
    }
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult DeletePost(int? id)
    {
        var obj = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);// (u => u.Id == id);

        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Subjects.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Subject deleted successfully";
        return RedirectToAction("Index");
    }
}



