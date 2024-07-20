using Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool IsDisplayed { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public ICollection<ProductImage> ProductImage { get; set; }
        public ICollection<ProductFeature> ProductFeature { get; set; }
    }

}
