using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Users : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
