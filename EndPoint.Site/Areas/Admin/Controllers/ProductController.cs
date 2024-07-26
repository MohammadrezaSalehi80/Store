using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Product.Command.AddProduct;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductFacad _productFacad;

        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(int page = 1, int pageSize = 20)

        {
            var product = _productFacad.GetProductForAdmin.Execute(page, pageSize).Result;

            return View(product);
        }


        public IActionResult Detail(long Id)
        {
            var productDetail = _productFacad.GetProductDetailForAdmin.Execute(Id).Result;
            return View();
        }


        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoryServices.Execute().Result, "Id", "Name");
            return View();
        }

        public IActionResult AddNewProduct(ProductRequestDto request, List<ProductFeatureDto> productFeatureDtos)
        {

            List<IFormFile> formFiles = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                formFiles.Add(file);
            }
            request.ProductImage = formFiles;
            request.ProductFeature = productFeatureDtos;

            var AddNewProduct = _productFacad.AddNewProductServices.Execute(request);

            return Json(AddNewProduct);

        }

    }
}
