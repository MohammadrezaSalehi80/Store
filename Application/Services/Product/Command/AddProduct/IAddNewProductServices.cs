using Store.Common.Dto;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Application.Services.Product.Command.AddProduct
{
    public interface IAddNewProductServices
    {
        public ResultDto<ProductResultDto> Execute(ProductRequestDto productRequestDto);
    }
}
