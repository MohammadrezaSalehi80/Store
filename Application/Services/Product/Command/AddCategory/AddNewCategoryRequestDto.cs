namespace Store.Application.Services.Product.Command.AddCategory
{
    public class AddNewCategoryRequestDto
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }

}
