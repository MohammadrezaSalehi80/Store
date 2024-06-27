using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Query;
using Store.Application.Services.Users.Query.GetRoles;
using Store.Application.Services.Users.Query.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Users : Controller
    {
        private readonly IGetUsersServices _getUsersServices;
        private readonly IGetRoles _getRoles;

        public Users(IGetUsersServices getUsersServices, IGetRoles getRoles)
        {
            _getRoles = getRoles;
            _getUsersServices = getUsersServices;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUsersServices.Execute(new RequestGetUsersDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRoles.Execute(), "Id", "Name");
            return View();
        }


    }
}
