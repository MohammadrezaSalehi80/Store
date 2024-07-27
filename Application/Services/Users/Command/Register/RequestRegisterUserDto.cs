using System.Collections.Generic;

namespace Store.Application.Services.Users.Command.Register
{
    public class RequestRegisterUserDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRolesDto> Roles { get; set; }
    }

}
