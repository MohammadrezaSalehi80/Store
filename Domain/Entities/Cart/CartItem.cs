using Store.Domain.Entities.Common;

namespace Store.Domain.Entities.Cart
{
    public class CartItem:BaseEntity
    {
        public long Id { get; set; }
        public Product.Product Product { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public Cart Cart { get; set; }
        public long CartId { get; set; }
    }

}
