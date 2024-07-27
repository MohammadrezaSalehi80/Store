using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Command.Delete;
using Store.Application.Services.Users.Command.Register;
using Store.Application.Services.Users.Query;
using Store.Application.Services.Users.Query.GetRoles;
using Store.Application.Services.Users.Query.GetUsers;
using System.Collections.Generic;
using System.Linq;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Users : Controller
    {
        private readonly IGetUsersServices _getUsersServices;
        private readonly IGetRoles _getRoles;
        private readonly IRegisterUsersServices _registerUsersServices;
        private readonly IDeleteUsersServices _deleteUsersServices;

        public Users(IGetUsersServices getUsersServices,
            IGetRoles getRoles, IRegisterUsersServices registerUsersServices,
            IDeleteUsersServices deleteUsersServices)
        {
            _getRoles = getRoles;
            _getUsersServices = getUsersServices;
            _registerUsersServices = registerUsersServices;
            _deleteUsersServices= deleteUsersServices;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUsersServices.Execute(new RequestGetUsersDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRoles.Execute(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name, string FamilyName, string Email, string password,
            string UserName, long RoleId)
        {
            var result = _registerUsersServices.Execute(new RequestRegisterUserDto()
            {
                Email = Email,
                Family = FamilyName,
                Name = Name,
                UserName = UserName,
                Password = password,
                Roles = new List<UserRolesDto> 
                { 
                    new UserRolesDto() { Id = RoleId } 
                }
            });

            return Json(result);

        }


        public IActionResult Remove(string Id)
        {
            var result = _deleteUsersServices.Execute(new DeleteUsersDto { Id = long.Parse(Id) });
            return Json(result);
        }


        public IActionResult Edit(string Id)
        {
            var result = _getUsersServices.Execute(new RequestGetUsersDto { Id = long.Parse(Id) });
            ViewBag.Roles = new SelectList(_getRoles.Execute(), "Id", "Name");
            return View(result);
        }

    }
}
