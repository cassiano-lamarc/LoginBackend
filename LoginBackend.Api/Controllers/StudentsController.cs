using Microsoft.AspNetCore.Mvc;

namespace LoginBackend.Api.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
