using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Product.Query.FetProductForSite
{
    public class FetProductForSiteServices : IFetProductForSiteServices
    {
        private readonly IDataBaseContext _context;

        public FetProductForSiteServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<ProductForSiteDto>> Execute(int page, string SearchKey, long? CategoryId = null)
        {
            int TotalPage = 0;
            var products = _context.Products
                .Include(p => p.ProductImage)
                .Include(p => p.Category)
                .ToList().AsQueryable();

            if (CategoryId != null)
                products = products.Where(p => p.CategoryId == (long)CategoryId
                    || p.Category.ParentId == (long)CategoryId).ToList().AsQueryable();

            if (!string.IsNullOrEmpty(SearchKey))
                products = products.Where(p => p.Name.Contains(SearchKey)).ToList().AsQueryable();

            var productsDto = products.ToPage(page, 5, out TotalPage).ToList();

            List<ProductForSiteDto> ProductList = new List<ProductForSiteDto>();

            Random random = new Random();

            foreach (var item in productsDto)
            {
                ProductList.Add(new ProductForSiteDto()
                {
                    Id = item.Id,
                    ImageSrc = item.ProductImage?.FirstOrDefault().Src,
                    Price = item.Price,
                    Star = random.Next(1, 5),
                    Title = item.Name
                });
            }


            return new ResultDto<List<ProductForSiteDto>>
            {
                IsSuccess = true,
                Message = "Success",
                Result = ProductList
            };


        }

    }
}
