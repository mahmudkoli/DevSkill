using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Web.Areas.Admin.Models
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
                    new MenuOption () { Controller = "Students", Action = "Index", DisplayText = "Student",
                        IconText = "icon-home4", IsActive = false },
                    new MenuOption () { Controller = "Courses", Action = "Index", DisplayText = "Course",
                        IconText = "icon-home4", IsActive = false },
                    new MenuOption () { Controller = "StudentRegistrations", Action = "Index", DisplayText = "Student Registration",
                        IconText = "icon-home4", IsActive = false }
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
