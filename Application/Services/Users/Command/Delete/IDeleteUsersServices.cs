using Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Command.Delete
{
    public interface IDeleteUsersServices
    {
        ResultDto Execute(DeleteUsersDto deleteUsersDto);
    }
}
