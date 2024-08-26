﻿using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePage.Query
{
    public interface IGetSliderServices
    {
        public ResultDto<List<GetSliderDto>> Execute();
    }

}
