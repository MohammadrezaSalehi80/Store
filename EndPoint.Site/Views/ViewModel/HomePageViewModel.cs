using Store.Application.Services.HomePage.Query;
using Store.Domain.Entities.HomePage;
using System.Collections.Generic;

namespace EndPoint.Site.Views.ViewModel
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> Slider { get; set; }
    }
}
