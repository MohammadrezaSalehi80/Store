using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System.Linq;

namespace Store.Application.Services.Product.Query.GetProductForAdmin
{
    public class GetProductForAdmin : IGetProductForAdmin
    {
        private readonly IDataBaseContext _context;

        public GetProductForAdmin(IDataBaseContext context)
        {
            _context = context;
        }   

        public ResultDto<ProductForAdminDto> Execute(int page, int pageSize = 20)
        {
            var rowCount = 0;
            var productList = _context.Products
                            .Include(p=> p.Category)
                            .ToPage(page,pageSize,out rowCount)
                            .Select(p => new ProductForAdminListDto
                            {
                                Id= p.Id,
                                Category= p.Category,
                                Inventory= p.Inventory,
                                IsDisplayed= p.IsDisplayed,
                                Name= p.Name,
                                Price = p.Price 
                            }).ToList();

            return new ResultDto<ProductForAdminDto>
            {
                IsSuccess = true,
                Message = "Success",
                Result = new ProductForAdminDto
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    ProductForAdminListDto = productList,
                    RowCount = rowCount
                }
            };

        }
    }
}
