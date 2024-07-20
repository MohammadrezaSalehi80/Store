using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Store.Application.Services.Product.Command.AddProduct
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool IsDisplayed { get; set; }
        public long CategoryId { get; set; }
        public List<IFormFile> ProductImage { get; set; }
        public List<ProductFeatureDto> ProductFeature { get; set; }
    }
}
