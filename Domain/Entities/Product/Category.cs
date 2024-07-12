using Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
    public class Category : BaseEntity
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public virtual Category Parent { get; set; }
        public long? ParentId { get; set; }

        public virtual ICollection<Category> SubCatgory { get; set; }
    }
}
