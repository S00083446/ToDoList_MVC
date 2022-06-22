using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;
using ToDoListUtility;

namespace BulkyBookWeb.Controllers;
[Area("Admin")]
//[Authorize(Roles = SD.Role_Admin)]
public class LecturerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public LecturerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        Lecturer lecturer = new();

        if (id == null || id == 0)
        {
            return View(lecturer);
        }
        else
        {
            lecturer = _unitOfWork.Lecturer.GetFirstOrDefault(u => u.Id == id);
            return View(lecturer);
        }
    }

    //POST
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
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        return View(obj);
    }



    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var LecturerList = _unitOfWork.Lecturer.GetAll();
        return Json(new { data = LecturerList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Lecturer.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.Lecturer.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
