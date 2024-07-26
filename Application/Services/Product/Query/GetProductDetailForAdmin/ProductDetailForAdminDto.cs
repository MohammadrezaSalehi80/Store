using Store.Domain.Entities.Product;
using System.Collections.Generic;

namespace Store.Application.Services.Product.Query.GetProductDetailForAdmin
{
    public class ProductDetailForAdminDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool IsDisplayed { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public ICollection<ProductDetailForAdmin_ProductImageDto> ProductImage { get; set; }
        public ICollection<ProductDetailForAdmin_ProductFeatureDto> ProductFeature { get; set; }
    }
}
