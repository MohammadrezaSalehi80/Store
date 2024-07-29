using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.GetCategory
{
    public class GetCategoryForSearchServices : IGetCategoryForSearchServices
    {

        private readonly IDataBaseContext _context;

        public GetCategoryForSearchServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoryForSearchDto>> Execute()
        {
            var Category = _context.Categories
                .Where(p=>p.ParentId == null)
                .ToList().Select(p=> new CategoryForSearchDto()
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return new ResultDto<List<CategoryForSearchDto>>()
            {
                IsSuccess = true,
                Message = "Success",
                Result = Category.ToList()
            };

        }
    }

}
