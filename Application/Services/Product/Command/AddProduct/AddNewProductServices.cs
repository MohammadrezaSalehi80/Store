using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Store.Application.Services.Product.Command.AddProduct
{
    public class AddNewProductServices : IAddNewProductServices
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IDataBaseContext _context;
        public AddNewProductServices(IWebHostEnvironment environment, IDataBaseContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ResultDto<ProductResultDto> Execute(ProductRequestDto productRequestDto)
        {
            var category = _context.Categories.Where(x => x.Id ==
            productRequestDto.CategoryId).FirstOrDefault();

            var product = new Domain.Entities.Product.Product
            {
                Category = category,
                CategoryId = productRequestDto.CategoryId,
                Description = productRequestDto.Description,
                Inventory = productRequestDto.Inventory,
                IsDisplayed = productRequestDto.IsDisplayed,
                Name = productRequestDto.Name,
                Price = productRequestDto.Price,
                CreateDate = DateTime.Now
            };

            _context.Products.Add(product);

            //AddProductFeature
            if (productRequestDto.ProductFeature.Count > 0)
            {
                AddProductFeature(productRequestDto, product);
            }

            List<ProductImage> productImage = new List<ProductImage>();
            if (productRequestDto.ProductImage.Count > 0)
            {

                foreach (var item in productRequestDto.ProductImage)
                {
                    var upload = Upload(item);
                    productImage.Add(new ProductImage()
                    {
                        Product = product,
                        CreateDate = DateTime.Now,
                        Src = upload.fileName
                    });
                }

                _context.ProductImages.AddRange(productImage);
            }

            _context.SaveChanges();
            return new ResultDto<ProductResultDto>()
            {
                IsSuccess = true,
                Message = "عملیات موفق آمیز بود",
                Result = new ProductResultDto() { ProductId = product.Id }
            };

        }


        private void AddProductFeature(ProductRequestDto productRequestDto, Domain.Entities.Product.Product product)
        {
            List<ProductFeature>  List= new List<ProductFeature>();
            foreach (var item in productRequestDto.ProductFeature)
            {
                List.Add(new ProductFeature()
                {
                    DisplayName = item.DisplayName,
                    CreateDate = DateTime.Now,
                    Product = product,
                    Value = item.Value,
                });
            }

            _context.ProductFeatures.AddRange(List);
        }


        private FileUploadDto Upload(IFormFile file)
        {
            string folder = $@"Images\ProductImages\";
            var root = Path.Combine(_environment.WebRootPath, folder);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            string fileName = file.Name + DateTime.Now.Ticks.ToString();
            var filePath = Path.Combine(root, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return new FileUploadDto()
            {
                fileName = filePath,
                IsSuccess = true,
            };
        }


    }
}
