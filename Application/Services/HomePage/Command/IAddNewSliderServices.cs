using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePage
{
    public interface IAddNewSliderServices
    {
        public ResultDto Execute(IFormFile formFile, string link);
    }
}
