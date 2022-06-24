using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using ToDoList.DataAccess.Repository.IRepository;
using ToDoListModels;

namespace ToDoListWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Detail> detailList = _unitOfWork.Detail.GetAll(includeProperties: "Subjects");
            return View(detailList);
        }


        public IActionResult Details(int detailId)
        {
            MoreDetails moreDetailsObj = new()
            {
                DetailId = detailId,
                Detail = _unitOfWork.Detail.GetFirstOrDefault(u => u.Id == detailId, includeProperties: "Subjects")
            };
        
            return View(moreDetailsObj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(MoreDetails moreDetails)
        { 
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            moreDetails.ApplicationUserId = claim.Value;


            _unitOfWork.MoreDetails.Add(moreDetails);
            _unitOfWork.Save();
           

            return RedirectToAction(nameof(Index));

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}