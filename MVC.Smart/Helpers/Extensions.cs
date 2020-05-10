using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC.Smart.Helpers
{
    public static class Extensions
    {
        public static string ToHamada(this string caller)
        {
            return "welcome " + caller;
        }

        public static MvcHtmlString UlFor(this HtmlHelper caller, IEnumerable<object> arr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (object item in arr)
            {
                sb.Append("<li>");
                sb.Append(item.ToString());
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}