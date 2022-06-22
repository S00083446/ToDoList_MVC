using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoListModels.ViewModels;

namespace ToDoListWeb.Areas.Admin.Controllers;
[Area("Admin")]
//[Route("api/[controller]/Subject")]
//[ApiController]
public class LecturerController : Controller
{
    //private readonly ApplicationDbContext _db;
    private readonly IUnitOfWork _unitOfWork;

    public LecturerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        //IEnumerable<Subjects> objSubjectsToList = _unitOfWork.Subjects.GetAll();

        //return View(objSubjectsToList);
        return View();
    }

    // GET
    public IActionResult Upsert(int? id)
    {
        //Detail detail = new();// using ViewModel instead
        Lecturer lecturer = new();
        if (id == null || id == 0)
        {
            // create lecturer object
            return View(lecturer);
        }
        else
        {
            lecturer = _unitOfWork.Lecturer.GetFirstOrDefault(u => u.Id == id);
            return View(lecturer);
        }
    }


    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Lecturer obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            if (obj.Id == 0)
            {
                _unitOfWork.Lecturer.Add(obj);
                TempData["success"] = "Lecturer created successfully";

            }
            else
            {
                _unitOfWork.Lecturer.Update(obj);
                TempData["success"] = "Lecturer updated successfully";

            }

            //_unitOfWork.Detail.Add(obj.Details);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //#region API CALLS
    //[HttpGet]
    //public IActionResult GetAll()
    //{
    //    var lectureList = _unitOfWork.Lecturer.GetAll();
    //    return Json(new { data = lectureList });
    //}

    // GET
    //public IActionResult Delete(int? id)
    //{
    //    if (id == null || id == 0)
    //    {
    //        return NotFound();
    //    }
    //    //var categoryFromDb = _db.Subjects.Find(id);

    //    //var categoryFromFirst = _db.FirstOrDefault(u => u.Id == id);
    //    var categoryFromDbFirst = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
    //    //var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

    //    //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

    //    if (categoryFromDbFirst == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(categoryFromDbFirst);
    //}

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Lecturer.GetFirstOrDefault(u => u.Id == id);// (u => u.Id == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

       
        _unitOfWork.Lecturer.Remove(obj);
        _unitOfWork.Save();
        //TempData["success"] = "Cover Type deleted successfully";
        return Json(new { success = true, message = "Delete Successfull" });

        //return RedirectToAction("Index");
    }




    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var lectureList = _unitOfWork.Lecturer.GetAll(includeProperties: "Subjects");
        return Json(new { data = lectureList });
    }

    ////POST
    //[HttpDelete]
    //public IActionResult Delete(int? id)
    //{
    //    var obj = _unitOfWork.Detail.GetFirstOrDefault(u => u.Id == id);// (u => u.Id == id);

    //    if (obj == null)
    //    {
    //        return Json(new { success = false, message = "Error while deleting" });
    //    }

    //    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
    //    if (System.IO.File.Exists(oldImagePath))
    //    {
    //        System.IO.File.Delete(oldImagePath);
    //    }
    //    _unitOfWork.Detail.Remove(obj);
    //    _unitOfWork.Save();
    //    //TempData["success"] = "Cover Type deleted successfully";
    //    return Json(new { success = true, message = "Delete Successfull" });

    //    //return RedirectToAction("Index");
    //}

    #endregion
}
// GET
//public IActionResult Delete(int? id)
//{
//    if (id == null || id == 0)
//    {
//        return NotFound();
//    }
//    //var categoryFromDb = _db.Subjects.Find(id);

//    //var categoryFromFirst = _db.FirstOrDefault(u => u.Id == id);
//    //var categoryFromDbFirst = _unitOfWork.Subjects.GetFirstOrDefault(u => u.Id == id);
//    //var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

//    //var categoryFromDbSingle = _db.Subjects.SingleOrDefault(u => u.Id == id);

//    //if (coverTypeFromDbFirst == null)
//    //{
//    //    return NotFound();
//    //}
//    //return View(coverTypeFromDbFirst);
//}
// POST
//[HttpPost]
//[ValidateAntiForgeryToken]

//public IActionResult DeletePost(int? id)
//{
//    var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);// (u => u.Id == id);

//    if (obj == null)
//    {
//        return NotFound();
//    }
//    _unitOfWork.CoverType.Remove(obj);
//    _unitOfWork.Save();
//    TempData["success"] = "Cover Type deleted successfully";
//    return RedirectToAction("Index");
//}



