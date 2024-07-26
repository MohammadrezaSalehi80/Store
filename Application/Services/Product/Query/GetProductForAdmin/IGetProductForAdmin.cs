using Store.Common.Dto;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.GetProductForAdmin
{
    public interface IGetProductForAdmin
    {
        public ResultDto<ProductForAdminDto> Execute(int page, int pageSize = 20);
    }
}
