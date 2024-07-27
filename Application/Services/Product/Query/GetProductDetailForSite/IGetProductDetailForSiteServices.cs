using Store.Application.Services.Product.Query.GetProductDetailForAdmin;
using Store.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.GetProductDetailForSite
{
    public interface IGetProductDetailForSiteServices
    {
        public ResultDto<ProductDetailForSiteDto> Execute(int Id);
    }
}
