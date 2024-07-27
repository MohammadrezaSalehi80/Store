using Store.Domain.Entities.Product;
using System;
using System.Collections.Generic;

namespace Store.Application.Services.Product.Query.GetProductDetailForSite
{
    public class ProductDetailForSiteDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool IsDisplayed { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public ICollection<String> ProductImageSrc { get; set; }
        public ICollection<ProductDetailForSite_ProductFeatureDto> ProductFeature { get; set; }
    }

}
