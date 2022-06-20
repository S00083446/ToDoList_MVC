using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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


        public IActionResult Details(int id)
        {
            MoreDetails moreDetails = new()
            {
                Detail = _unitOfWork.Detail.GetFirstOrDefault(u => u.Id == id, includeProperties: "Subjects")
            };
        
            return View(moreDetails);

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