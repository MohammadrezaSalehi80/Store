using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Common.GetMenu;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenuItem : ViewComponent
    {

        private readonly IGetMenuServices _services;

        public GetMenuItem(IGetMenuServices getMenuServices)
        {
            _services = getMenuServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName: "GetMenuItem", _services.Execute().Result);
        }

    }
}
