using Store.Application.Interfaces.Context;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Product.Command;
using Store.Application.Services.Product.Query;
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
        private AddNewCategoryServices _addNewCategory;
        private GetCategoryServices _getCategory;
        public ProductFacad(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public AddNewCategoryServices AddNewCategoryServices => 
            _addNewCategory?? new AddNewCategoryServices(_dataBaseContext);

        public GetCategoryServices GetCategoryServices =>
            _getCategory ?? new GetCategoryServices(_dataBaseContext);

    }
}
