using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers.Base
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
