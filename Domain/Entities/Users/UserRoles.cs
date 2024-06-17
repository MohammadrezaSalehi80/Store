namespace Store.Domain.Entities.Users
{
    public class UserRoles
    {
        public long Id { get; set; }

        public virtual Users Users { get; set; }   
        public long UserId { get; set; }

        public virtual Roles Roles { get; set; }
        public long RoleId { get; set; }
    }

}
