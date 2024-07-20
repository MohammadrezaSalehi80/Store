using Store.Application.Services.Product.Command.AddCategory;
using Store.Application.Services.Product.Command.AddProduct;
using Store.Application.Services.Product.Query.GetAllCategory;
using Store.Application.Services.Product.Query.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces.FacadPattern
{
    public interface IProductFacad
    {
        AddNewCategoryServices AddNewCategoryServices { get; }
        GetCategoryServices GetCategoryServices { get; }
        GetAllCategoryServices GetAllCategoryServices { get; }


        AddNewProductServices AddNewProductServices { get; }
    }
}
