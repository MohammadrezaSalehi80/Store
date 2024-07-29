using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.GetCategory
{
    public interface IGetCategoryForSearchServices
    {
        public ResultDto<List<CategoryForSearchDto>> Execute();
    }
}
