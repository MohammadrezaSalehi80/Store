using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Product.Command.AddCategory;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductFacad _productFacad;

        public CategoryController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(long? ParentId)
        
        
        {
            return View(_productFacad.GetCategoryServices.Execute(ParentId));
        }


        [HttpGet]
        public IActionResult Create(long? parentId)
        {
            ViewBag.ParentId = parentId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddNewCategoryRequestDto addNewCategoryRequestDto)
        {
            var result = _productFacad.AddNewCategoryServices.Execute(addNewCategoryRequestDto);

            return Json(result);
        }
    }
}
