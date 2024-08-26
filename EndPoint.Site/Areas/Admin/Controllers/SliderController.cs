using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Store.Application.Services.HomePage;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IAddNewSliderServices _addNewSliderServices;

        public SliderController(IAddNewSliderServices addNewSliderServices)
        {
            _addNewSliderServices = addNewSliderServices;
        }

        public IActionResult AddSlider()
        {
            return View();
        }

        public IActionResult Create(IFormFile imageSrc, string link) 
        {

            IFormFile formFiles = Request.Form.Files[0];
            imageSrc = formFiles;


            return Json(_addNewSliderServices.Execute(imageSrc, link));
        }

    }
}
