using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Common.GetMenu
{
    public class GetMenuServices : IGetMenuServices
    {
        private readonly IDataBaseContext _context;

        public GetMenuServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetMenuItemDto>> Execute()
        {
            var MenuItem = _context.Categories
                .Include(p => p.SubCatgory)
                .Where(p => p.ParentId == null)
                .ToList()
                .Select(p => new GetMenuItemDto()
                {
                    Id= p.Id,
                    Name= p.Name,  
                    Child = p.SubCatgory.ToList().Select(p => new GetMenuItemDto()
                    {
                        Id= p.Id,
                        Name= p.Name,
                    }).ToList()
                });

            return new ResultDto<List<GetMenuItemDto>> {
                IsSuccess = true,
                Message = "Success",
                Result = MenuItem.ToList()
            };
        }
    }

}
