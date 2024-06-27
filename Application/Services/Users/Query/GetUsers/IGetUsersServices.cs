using Store.Domain.Entities.Users;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Query.GetUsers
{
    public interface IGetUsersServices
    {
        ResultGetUsersDto Execute(RequestGetUsersDto request);
    }


}
