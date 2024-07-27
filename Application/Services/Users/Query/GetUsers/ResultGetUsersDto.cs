using System.Collections.Generic;

namespace Store.Application.Services.Users.Query.GetUsers
{
    public class ResultGetUsersDto
    {
        public List<GetUsersDto> users { get; set; }
        public int Rows { get; set; }
    }


}
