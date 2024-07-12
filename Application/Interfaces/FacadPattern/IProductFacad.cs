using Store.Application.Services.Product.Command;
using Store.Application.Services.Product.Query;
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
    }
}
