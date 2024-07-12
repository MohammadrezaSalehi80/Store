using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Query.Login
{
    public interface ILoginService
    {
        public ResultDto<LoginResultDto> Execute(LoginRequestDto Request);
    }

}
