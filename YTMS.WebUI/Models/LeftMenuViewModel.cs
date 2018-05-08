using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YTMS.WebUI
{
    public class LeftMenuViewModel
    {
        public int MenuId { get; set; }

        public string Href { get; set; }

        public string Text { get; set; }

        public bool IsSelected { get; set; }

        public string ClassStyle { get; set; }
    }
}