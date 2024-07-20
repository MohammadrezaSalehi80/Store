using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.GetAllCategory
{
    public interface IGetAllCategoryServices
    {
        ResultDto<List<GetAllCategoryDto>> Execute();
    }


}
