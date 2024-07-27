using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Query.GetRoles
{
    public interface IGetRoles
    {
        List<RoleResult> Execute();
    }
}
