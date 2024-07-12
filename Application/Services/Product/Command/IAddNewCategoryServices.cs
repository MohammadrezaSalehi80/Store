using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Command
{
    public interface IAddNewCategoryServices
    {
        ResultDto<AddNewCategoryResultDto> Execute(AddNewCategoryRequestDto request);
    }

}
