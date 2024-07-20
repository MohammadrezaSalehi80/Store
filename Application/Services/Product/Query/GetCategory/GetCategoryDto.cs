namespace Store.Application.Services.Product.Query.GetCategory
{
    public class GetCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public bool hasChild { get; set; }
        public ParentCategoryDto parentCategoryDto { get; set; }
    }

}
