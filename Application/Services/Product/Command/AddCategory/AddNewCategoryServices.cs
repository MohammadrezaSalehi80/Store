using Store.Application.Interfaces.Context;
using Store.Common.Dto;
using Store.Domain.Entities.Product;
using System;

namespace Store.Application.Services.Product.Command.AddCategory
{
    public class AddNewCategoryServices : IAddNewCategoryServices
    {
        private readonly IDataBaseContext _dataBaseContext;

        public AddNewCategoryServices(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto<AddNewCategoryResultDto> Execute(AddNewCategoryRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Name))
                return new ResultDto<AddNewCategoryResultDto>
                {
                    IsSuccess = false,
                    Message = "لطفا نام را وارد کنید",
                    Result = null
                };


            Category category = new Category()
            {
                CreateDate = DateTime.Now,
                Name = request.Name,
                ParentId = request.ParentId,
            };

            _dataBaseContext.Categories.Add(category);
            _dataBaseContext.SaveChanges();

            return new ResultDto<AddNewCategoryResultDto>
            {
                IsSuccess = true,
                Result = new AddNewCategoryResultDto() { ProductId = category.Id },
                Message = "دسته بندی با موفقیت اضافه شد"
            };

        }

    }

}
