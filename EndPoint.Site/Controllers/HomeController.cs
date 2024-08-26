using EndPoint.Site.Models;
using EndPoint.Site.Views.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Application.Services.HomePage.Query;
using Store.Application.Services.Product.Query.GetAllCategory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGetSliderServices _getSliderServices;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment, IGetSliderServices getSliderServices)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _getSliderServices = getSliderServices;
        }

        public IActionResult Index()
        {
            var slider = _getSliderServices.Execute();
            HomePageViewModel homePageViewModel = new HomePageViewModel() { Slider = slider.Result};
            return View(homePageViewModel);
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
