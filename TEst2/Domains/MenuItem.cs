using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Domains
{
    public enum MenuItemAction { Search, None, Excel, Xml, Users}
    public class MenuItem
    {
        public MenuItemAction MenuType { get; set; }
        public String Text { get; set; }
        public List<MenuItem> Items{ get; set; }
    }
}
