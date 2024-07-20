using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.GetCategory
{
    public interface IGetCategoryServices
    {
        public List<GetCategoryDto> Execute(long? ParentId);
    }

}
