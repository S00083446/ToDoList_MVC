using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;
using System.Collections.Generic;

namespace ToDoListWeb.Areas.Admin.Controllers;
[Area("Admin")]
//[Route("api/[controller]/Subject")]
//[ApiController]
public class DetailController : Controller
{
    //private readonly ApplicationDbContext _db;
    private readonly IUnitOfWork _unitOfWork;

    public DetailController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();

        return View(objCoverTypeList);
    }

    //// GET
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST
    //[HttpPost]
    //[ValidateAntiForgeryToken]

    //public IActionResult Create(CoverType obj)
    //{ 
        
    //    if (ModelState.IsValid)
    //    {
    //        _unitOfWork.CoverType.Add(obj);
    //        _unitOfWork.Save();
    //        TempData["success"] = "Cover Type created successfully";
    //        return RedirectToAction("Index");
    //    }
    //    return View(obj);
    //}

    // GET
    public IActionResult Upsert(int? id)
    {
        Detail detail = new();
        if (id == null || id == 0)
        {
            // create details
            return View(detail);
        }
        else
        {
            // update detils
        }
        
        return View(detail);
    }
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(CoverType obj)
    {
      if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type updated successfully";
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
        //var categoryFromDbFirst = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
        var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

        if (coverTypeFromDbFirst == null)
        {
            return NotFound();
        }
        return View(coverTypeFromDbFirst);
    }
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult DeletePost(int? id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);// (u => u.Id == id);

        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Cover Type deleted successfully";
        return RedirectToAction("Index");
    }
}



