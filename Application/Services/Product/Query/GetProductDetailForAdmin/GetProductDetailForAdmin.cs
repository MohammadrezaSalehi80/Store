using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Product.Query.GetProductDetailForAdmin
{
    public class GetProductDetailForAdmin : IGetProductDetailForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailForAdmin(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForAdminDto> Execute(long Id)
        {
            var Product = _context.Products
                            .Include(p=>p.Category)
                            .ThenInclude(p=> p.Parent)
                            .Include(p=> p.ProductFeature)
                            .Include(p=>p.ProductImage)
                            .Where(p=>p.Id== Id)
                            .FirstOrDefault();

            List<ProductDetailForAdmin_ProductFeatureDto> feature = new List<ProductDetailForAdmin_ProductFeatureDto>();
            foreach (var item in Product.ProductFeature)
            {
                feature.Add(new ProductDetailForAdmin_ProductFeatureDto
                {
                    Id = item.Id,
                    DisplayName = item.DisplayName,
                    Value = item.Value,
                });
            }

            List<ProductDetailForAdmin_ProductImageDto> image = new List<ProductDetailForAdmin_ProductImageDto>();
            foreach (var item in Product.ProductImage)
            {
                image.Add(new ProductDetailForAdmin_ProductImageDto
                {
                    Id= item.Id,
                    Src= item.Src
                });
            }




            return new ResultDto<ProductDetailForAdminDto>
            {
                IsSuccess = true,
                Message = "Success",
                Result = new ProductDetailForAdminDto
                {
                    Id = Id,
                    Category = Product.Category,
                    Description = Product.Description,
                    Inventory = Product.Inventory,
                    IsDisplayed = Product.IsDisplayed,
                    Name = Product.Name,
                    Price = Product.Price,
                    CategoryId = Product.CategoryId,
                    ProductFeature = feature,
                    ProductImage = image
                }
            };

        }
    }
}
