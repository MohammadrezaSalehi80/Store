using Store.Common.Dto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.GetMenu
{
    public interface IGetMenuServices
    {
        public ResultDto<List<GetMenuItemDto>> Execute();
    }
}
