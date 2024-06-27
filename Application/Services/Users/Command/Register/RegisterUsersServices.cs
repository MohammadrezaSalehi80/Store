
using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
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
                    Roles= roles,
                    Users= users,
                    UserId= users.Id
                });
            }

            users.UserRoles = rolesList;
            _DataBaseContext.Users.Add(users);
            _DataBaseContext.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                IsSuccess = true,
                Message = "Save Is Success",
                Result = new ResultRegisterUserDto()
                {
                    UserId = users.Id
                }
            };
        }
    }

}
