using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.Register;
using Store.Application.Services.Users.Query.Login;
using System.Collections.Generic;
using System.Security.Claims;

namespace EndPoint.Site.Controllers
{
    public class Authentication : Controller
    {
        private readonly IRegisterUsersServices _registerUsersServices;
        private readonly ILoginService _loginService;

        public Authentication(IRegisterUsersServices registerUsersServices, ILoginService loginService)
        {
            _registerUsersServices = registerUsersServices;
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View("~/Views/Authentication/Signup.cshtml");
        }


        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            var result = _registerUsersServices.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                Family = request.Family,
                Name = request.Name,
                UserName = request.UserName,
                Password = request.Password,
                Roles = new List<UserRolesDto> { new UserRolesDto() { Id = 3 } }

            });

            if (result.IsSuccess)
            {
                var claim = new List<Claim>() { new Claim(
                           ClaimTypes.NameIdentifier,
                           result.Result.UserId.ToString()
                    ),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, request.Name + " " + request.Family),
                    new Claim(ClaimTypes.Role, "Customer"),


                };

                //User.Identity.Name

                var identity = new ClaimsIdentity(claim,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var propertis = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, propertis);


            }

            return Json(result);
        }


        [HttpGet]
        public IActionResult Signin()
        {
            return View("~/Views/Authentication/Signin.cshtml");
        }


        [HttpPost]
        public IActionResult Signin(LoginRequestDto loginRequestDto)
        {

            var loginRespones = _loginService.Execute(loginRequestDto);


            if (loginRespones.IsSuccess)
            {
                var claim = new List<Claim>() { new Claim(
                           ClaimTypes.NameIdentifier,
                           loginRespones.Result.UserId.ToString()
                    ),
                    new Claim(ClaimTypes.Email, loginRespones.Result.Email),
                    new Claim(ClaimTypes.Name, loginRespones.Result.Name + " " + loginRespones.Result.Family),
                    new Claim(ClaimTypes.Role, "Customer"),


                };

                //User.Identity.Name

                var identity = new ClaimsIdentity(claim,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var propertis = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, propertis);


            }



            return Json(loginRespones);

        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public class SignUpViewModel
        {
            public string Name { get; set; }
            public string Family { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string RePassword { get; set; }
        }

    }
}
