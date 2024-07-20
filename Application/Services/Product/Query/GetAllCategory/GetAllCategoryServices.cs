using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Product.Query.GetAllCategory
{
    public class GetAllCategoryServices : IGetAllCategoryServices
    {
        private readonly IDataBaseContext _context;
        public GetAllCategoryServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetAllCategoryDto>> Execute()
        {
            var AllCategory = _context
                .Categories
                .Include(p=> p.Parent)
                .Where(p=> p.ParentId != null)
                .ToList()
                .Select(p=> new GetAllCategoryDto()
                {
                    Id = p.Id,
                    Name = p.Name + "-" + p.Parent.Name,
                }).ToList();
                

            return new ResultDto<List<GetAllCategoryDto>>
            { 
                IsSuccess= true,
                Message = "IsSuccsess",
                Result = AllCategory
            };

        }


    }


}
