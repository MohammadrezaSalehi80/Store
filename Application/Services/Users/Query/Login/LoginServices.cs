using Store.Application.Interfaces.Context;
using Store.Common;
using Store.Common.Dto;
using System.Linq;

namespace Store.Application.Services.Users.Query.Login
{
    public class LoginServices : ILoginService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public LoginServices(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto<LoginResultDto> Execute(LoginRequestDto Request)
        {
            var User = _dataBaseContext.Users.Where(x => x.UserName == Request.UserName).FirstOrDefault();

            if (User == null)
            {
                return new ResultDto<LoginResultDto>()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "کاربری یافت نشد"
                };
            }

            var IsValidPassword = new PasswordHasher().VerifyPassword(User.Password, Request.Password);
            if (!IsValidPassword)
            {
                return new ResultDto<LoginResultDto>()
                {
                    Result = null,
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه است"
                };
            }

            return new ResultDto<LoginResultDto>()
            {
                Result = new LoginResultDto()
                {
                    Email = User.Email,
                    Family = User.Family,
                    Name = User.Name,
                    UserId = User.Id,
                    UserName = User.UserName
                },
                IsSuccess = true,
                Message = "ورود موفق آمیز بود"
            };

        }

    }

}
