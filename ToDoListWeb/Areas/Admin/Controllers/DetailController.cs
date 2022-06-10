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
public class DetailController : Controller
{
    //private readonly ApplicationDbContext _db;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment  _hostEnvironment;



    public DetailController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }
    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();

        return View(objCoverTypeList);
    }

    // GET
    public IActionResult Upsert(int? id)
    {
        //Detail detail = new();// using ViewModel instead
        DetailsViewModel detailsVM = new()
        {
            Details = new(),
            SubjectList = _unitOfWork.Subjects.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            })
        };
        //IEnumerable<SelectListItem> SubjectList = _unitOfWork.Subjects.GetAll().Select(
        //    u => new SelectListItem
        //    {
        //        Text = u.Name, 
        //        Value = u.Id.ToString()
        //    }
        //); 


        if (id == null || id == 0)
        {
            //// create details
            //ViewBag.SubjectList = SubjectList;
            //// ViewData["SubjectList"] = SubjectList;
            return View(detailsVM);
        }
        else
        {
            // update detils
        }

        return View(detailsVM);



        //DetailsViewModel detailsVM = new()
        //{
        //    Details = new(),
        //    SubjectList = _unitOfWork.Subjects.GetAll().Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    }),


        //    u => new SelectListItem
        //    {
        //        Text = u.Name,
        //        Value = u.Id.ToString()
        //    });

    }
    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(DetailsViewModel obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRoothPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRoothPath, @"Images\subjects");
                var extension = Path.GetExtension(file.FileName);

                //copy file that was uploaded into folder
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
            obj.Details.ImageUrl = @"\Images\subjects\" + fileName + extension;
            }
            _unitOfWork.Detail.Add(obj.Details);
            _unitOfWork.Save();
            TempData["success"] = "Todo updated successfully";
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



