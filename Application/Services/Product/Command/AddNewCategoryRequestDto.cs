namespace Store.Application.Services.Product.Command
{
    public class AddNewCategoryRequestDto
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }

}
