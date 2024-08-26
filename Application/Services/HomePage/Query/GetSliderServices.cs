using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.HomePage.Query
{
    public class GetSliderServices : IGetSliderServices
    {
        private readonly IDataBaseContext _context;

        public GetSliderServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetSliderDto>> Execute()
        {
            var sliders = _context.sliders.Select(p => new GetSliderDto()
            {
                Id= p.Id,
                Link = p.Link,
                Src = p.ImageSrc
            }).ToList();

            return new ResultDto<List<GetSliderDto>> { IsSuccess = true, Message = "IsSuccess", Result = sliders};

        }
    }

}
