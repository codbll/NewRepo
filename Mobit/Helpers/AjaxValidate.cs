using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobit.Helpers
{
    public static class AjaxValidate
    {
        public static MvcHtmlString AntiForgeryTokenForAjaxPost(this HtmlHelper helper)
        {
            var antiForgeryInputTag = helper.AntiForgeryToken().ToString();
            var removedStart = antiForgeryInputTag.Replace(@"<input name=""__RequestVerificationToken"" type=""hidden"" value=""", "");
            var tokenValue = removedStart.Replace(@""" />", "");
            if (antiForgeryInputTag == removedStart || removedStart == tokenValue)
                throw new InvalidOperationException("Oops! The Html.AntiForgeryToken() method beklenmedik hata dondurdu.");
            return new MvcHtmlString(string.Format(@"{0}:""{1}""", "__RequestVerificationToken", tokenValue));
        }

    }

}