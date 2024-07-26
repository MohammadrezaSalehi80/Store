using Store.Domain.Entities.Product;

namespace Store.Application.Services.Product.Query.GetProductForAdmin
{
    public class ProductForAdminListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool IsDisplayed { get; set; }
        public virtual Category Category { get; set; }
    }
}
