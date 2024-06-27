using Store.Application.Interfaces.Context;
using System.Collections.Generic;
using System.Linq;

namespace Store.Application.Services.Users.Query.GetRoles
{
    public class GetRoles : IGetRoles
    {
        private readonly IDataBaseContext _dataBaseContext;
        public GetRoles(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public List<RoleResult> Execute()
        {
            var result = _dataBaseContext.Roles.Select(p => new RoleResult()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return result;
        }
    }



}
