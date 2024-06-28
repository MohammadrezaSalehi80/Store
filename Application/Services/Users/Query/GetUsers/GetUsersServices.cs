using Store.Application.Interfaces.Context;
using Store.Common;
using System.Linq;

namespace Store.Application.Services.Users.Query.GetUsers
{
    public class GetUsersServices : IGetUsersServices
    {
        private readonly IDataBaseContext _context;

        public GetUsersServices(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUsersDto Execute(RequestGetUsersDto request)
        {
            var user = _context.Users.AsQueryable();

            if (request.Id != 0 && request.Id != null)
            {
                user = user.Where(p => p.Id == request.Id);

                var res = user.Select(p => new GetUsersDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email= p.Email,
                    Family = p.Family,
                    UserName = p.UserName
                }).ToList();

                return new ResultGetUsersDto
                {
                    users = res,
                    Rows = res.Count
                };
            }

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {

                user = user.Where(user => user.Name.Contains(request.SearchKey)
                || user.Family.Contains(request.SearchKey));

            }

            int rowsCount;

            var result = user.ToPage(request.Page, 20, out rowsCount).Select(p =>
            new GetUsersDto
            {
                Id = p.Id,
                Email = p.Email,
                Name = p.Name,
                Family = p.Family
            }).ToList();


            return new ResultGetUsersDto
            {
                users = result,
                Rows = result.Count
            };

        }
    }


}
