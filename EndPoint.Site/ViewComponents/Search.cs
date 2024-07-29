using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Common.GetCategory;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetCategoryForSearchServices _getCategoryForSearch;

        public Search(IGetCategoryForSearchServices getCategoryForSearch)
        {
            _getCategoryForSearch = getCategoryForSearch;
        }   
        
        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search", _getCategoryForSearch.Execute().Result);
        }

    }
}
