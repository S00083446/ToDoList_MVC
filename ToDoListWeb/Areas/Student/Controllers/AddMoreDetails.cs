using Microsoft.AspNetCore.Mvc;

namespace ToDoListWeb.Areas.Student.Controllers
{
    [Area("Student")]
    public class AddMoreDetails : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
