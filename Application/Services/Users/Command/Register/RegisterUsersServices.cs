
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using Entitiy = Store.Domain.Entities.Users;

namespace Store.Application.Services.Users.Command.Register
{
    public class RegisterUsersServices : IRegisterUsersServices
    {
        private readonly IDataBaseContext _DataBaseContext;

        public RegisterUsersServices(IDataBaseContext dataBaseContext)
        {
            _DataBaseContext = dataBaseContext;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {

                if (request.Email == null
                    || request.Roles == null
                    || request.UserName == null
                    || request.Name == null
                    || request.Family == null
                    || request.Password == null
                    )
                {

                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        IsSuccess = false,
                        Message = "لطفا تمامی فیلد هارا تکمیل کنید",
                        Result = new ResultRegisterUserDto()
                        {
                            UserId = 0
                        }
                    };
                }

                Entitiy.Users users = new Entitiy.Users
                {
                    Email = request.Email,
                    Family = request.Family,
                    Name = request.Name,
                    UserName = request.UserName
                };

                Roles roles = new Roles();
                List<UserRoles> rolesList = new List<UserRoles>();
                foreach (var item in request.Roles)
                {
                    roles = _DataBaseContext.Roles.Find(item.Id);
                    rolesList.Add(new UserRoles
                    {
                        RoleId = roles.Id,
                        Roles = roles,
                        Users = users,
                        UserId = users.Id
                    });
                }

                users.UserRoles = rolesList;
                users.CreateDate = DateTime.Now;
                _DataBaseContext.Users.Add(users);
                _DataBaseContext.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد",
                    Result = new ResultRegisterUserDto()
                    {
                        UserId = users.Id
                    }
                };
            }
            catch
            {

                return new ResultDto<ResultRegisterUserDto>()
                {
                    IsSuccess = false,
                    Message = "عملیات با شکست مواجه شد!",
                    Result = new ResultRegisterUserDto()
                    {
                        UserId = 0
                    }
                };
            }
        }
    }

}
