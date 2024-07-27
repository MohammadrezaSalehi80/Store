using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Product.Query.GetProductDetailForSite
{
    public class GetProductDetailForSiteServices : IGetProductDetailForSiteServices
    {

        private readonly IDataBaseContext _context;

        public GetProductDetailForSiteServices(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto<ProductDetailForSiteDto> Execute(int Id)
        {
            var product = _context.Products
                .Include(p=>p.Category)
                .ThenInclude(p=> p.Parent)
                .Include(p=> p.ProductFeature)
                .Include(p=> p.ProductImage)
                .Where(p=> p.Id == Id)
                .FirstOrDefault();


            List<string> imgSrc= new List<string>();
            foreach(var item in product.ProductImage)
            {
                imgSrc.Add(item.Src);
            }


            List<ProductDetailForSite_ProductFeatureDto> productFeatureDtos 
                = new List<ProductDetailForSite_ProductFeatureDto>();

            foreach(var item in product.ProductFeature)
            {
                productFeatureDtos.Add(new ProductDetailForSite_ProductFeatureDto()
                {
                    DisplayName = item.DisplayName,
                    Value = item.Value,
                });
            }


            return new ResultDto<ProductDetailForSiteDto>()
            {
                IsSuccess = true,
                Message = "Success",
                Result = new ProductDetailForSiteDto()
                {
                    Category = product.Category,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    IsDisplayed = product.IsDisplayed,
                    Name = product.Name,
                    Price = product.Price,
                    ProductFeature = productFeatureDtos,
                    ProductImageSrc = imgSrc
                }
            };


        }
    }

}
