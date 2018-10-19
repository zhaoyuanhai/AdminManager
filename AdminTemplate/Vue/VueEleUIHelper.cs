using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.Vue
{
    public class VueElementUIHelper
    {
        public VueElementUIHelper(HtmlHelper html)
        {
            this.Html = html;
        }

        public HtmlHelper Html { get; set; }
    }
}