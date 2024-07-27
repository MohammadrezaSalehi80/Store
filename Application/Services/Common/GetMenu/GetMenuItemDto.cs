using System;
using System.Collections.Generic;

namespace Store.Application.Services.Common.GetMenu
{
    public class GetMenuItemDto
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public List<GetMenuItemDto> Child { get; set; }
    }

}
