using Store.Domain.Entities.Common;

namespace Store.Domain.Entities.Users
{
    public class UserRoles : BaseEntity
    {
        public long Id { get; set; }

        public virtual Users Users { get; set; }
        public long UserId { get; set; }

        public virtual Roles Roles { get; set; }
        public long RoleId { get; set; }
    }

}
