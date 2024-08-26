using Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Cart
{
    public class Cart : BaseEntity
    {
        public long Id { get; set; }
        public Guid BrowserId { get; set; }
        public Users.Users Users { get; set; }
        public long UsersId { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
        public bool IsFinished { get; set; }
    }
}
