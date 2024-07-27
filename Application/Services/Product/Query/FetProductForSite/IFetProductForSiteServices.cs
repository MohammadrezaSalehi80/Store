using Microsoft.EntityFrameworkCore;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.FetProductForSite
{
    public interface IFetProductForSiteServices
    {
        public ResultDto<List<ProductForSiteDto>> Execute(int page, long? CatId);
    }
}
