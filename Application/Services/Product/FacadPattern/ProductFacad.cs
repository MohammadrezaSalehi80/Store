using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Product.Command.AddCategory;
using Store.Application.Services.Product.Command.AddProduct;
using Store.Application.Services.Product.Query.GetAllCategory;
using Store.Application.Services.Product.Query.GetCategory;
using Store.Application.Services.Product.Query.GetProductDetailForAdmin;
using Store.Application.Services.Product.Query.GetProductForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _dataBaseContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private AddNewCategoryServices _addNewCategory;
        private GetCategoryServices _getCategory;
        private AddNewProductServices _addNewProduct;
        private GetAllCategoryServices _getAllCategory;
        private GetProductForAdmin _GetProductForAdmin;
        private GetProductDetailForAdmin _GetProductDetailForAdmin;

        public ProductFacad(IDataBaseContext dataBaseContext, IWebHostEnvironment webHostEnvironment)
        {
            _hostingEnvironment = webHostEnvironment;
            _dataBaseContext = dataBaseContext;
        }

        public AddNewCategoryServices AddNewCategoryServices =>
            _addNewCategory ?? new AddNewCategoryServices(_dataBaseContext);

        public GetCategoryServices GetCategoryServices =>
            _getCategory ?? new GetCategoryServices(_dataBaseContext);

        public AddNewProductServices AddNewProductServices => _addNewProduct ??
            new AddNewProductServices(_hostingEnvironment, _dataBaseContext);

        public GetAllCategoryServices GetAllCategoryServices => _getAllCategory ??
            new GetAllCategoryServices(_dataBaseContext);

        public GetProductForAdmin GetProductForAdmin => _GetProductForAdmin ?? new GetProductForAdmin(_dataBaseContext);

        public GetProductDetailForAdmin GetProductDetailForAdmin => _GetProductDetailForAdmin ??
            new GetProductDetailForAdmin(_dataBaseContext);
    }
}
