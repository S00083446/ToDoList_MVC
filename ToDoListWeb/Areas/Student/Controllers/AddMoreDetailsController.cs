using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels.ViewModels;

namespace ToDoListWeb.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class AddMoreDetailsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoreDetailsVM  MoreDetailsVM { get; set; }
        public AddMoreDetailsController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            MoreDetailsVM = new MoreDetailsVM() // get all todos for the user
            {
                ToDoList = _unitOfWork.MoreDetails.GetAll( u => u.ApplicationUserId ==
                claim.Value, includeProperties: "Detail")
            };
             
            return View(MoreDetailsVM);
        }


        public IActionResult Remove(int toDoId)
        {
            var toDo = _unitOfWork.MoreDetails.GetFirstOrDefault(u => u.Id == toDoId);
            _unitOfWork.MoreDetails.Remove(toDo);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
