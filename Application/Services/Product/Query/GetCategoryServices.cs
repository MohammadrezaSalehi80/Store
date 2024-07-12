using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Context;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Product.Query
{
    public class GetCategoryServices : IGetCategoryServices
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetCategoryServices(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }


        public List<GetCategoryDto> Execute(long? ParentId)
        {
            var categoris = _dataBaseContext.Categories.
                Include(p => p.Parent)
                .Include(p => p.SubCatgory)
                .Where(p => p.ParentId == ParentId)
                .ToList()
                .Select(p => new GetCategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ParentId = p.ParentId,
                    parentCategoryDto = p.Parent != null ? new ParentCategoryDto
                    {
                        Id = p.Parent.Id,
                        Name = p.Parent.Name,
                    } : null,
                    hasChild = p.SubCatgory.Count() > 0 ? true : false
                }).ToList();

            return categoris;

        }
    }

}
