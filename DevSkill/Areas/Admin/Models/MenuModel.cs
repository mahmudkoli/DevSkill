using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSkill.Areas.Admin.Models
{
    public class MenuModel
    {
        public List<MenuOption> MenuList
        {
            get
            {
                return new List<MenuOption>
                {
                    new MenuOption () { Controller = "Dashboard", Action = "Index", DisplayText = "Dashboard", 
                        IconText = "icon-home4", IsActive = false },
                    new MenuOption () { Controller = "Products", Action = "Index", DisplayText = "Product", 
                        IconText = "icon-home4", IsActive = true }
                };
            }
        }
    }

    public class MenuOption
    {
        public string Area { get { return "Admin"; } }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string DisplayText { get; set; }
        public string IconText { get; set; }
        public bool IsActive { get; set; }
    }
}