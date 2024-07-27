using Store.Domain.Entities.Common;

namespace Store.Domain.Entities.Product
{
    public class ProductFeature : BaseEntity
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }

}
