namespace Store.Application.Services.Users.Query.GetUsers
{
    public class RequestGetUsersDto
    {
        public long? Id { get; set; }
        public string SearchKey { get; set; }
        public int Page { get; set; }
    }


}
