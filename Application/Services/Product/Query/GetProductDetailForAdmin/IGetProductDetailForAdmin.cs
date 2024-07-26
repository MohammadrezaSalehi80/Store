using Microsoft.AspNetCore.Mvc;
using Store.Common.Dto;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Query.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdmin
    {
        public ResultDto<ProductDetailForAdminDto> Execute(long Id);
    }
}
