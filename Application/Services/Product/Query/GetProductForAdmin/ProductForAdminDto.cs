using System.Collections.Generic;

namespace Store.Application.Services.Product.Query.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public List<ProductForAdminListDto> ProductForAdminListDto { get; set; }
    }
}
