using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YTMS.WebUI
{

    public class LeftMenuViewModel
    {
        public MenuTypeEnum MenuType { get; set; }

        public int ActionMenuId { get; set; }
    }

    public class LeftMenuItem
    {
        public int MenuId { get; set; }

        public string Href { get; set; }

        public string Text { get; set; }


        public string ClassStyle { get; set; }
    }

    public enum MenuTypeEnum
    {
        SystemConfig,
        WorkingTab
    }
}