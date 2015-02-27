using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZiJingHu.Models;

namespace ZiJingHu.Controllers
{
    public class HelperController : Controller
    {
        //
        // GET: /Helper/

        //customized
        public ContentResult GetHtmlFile()
        {
            return Content(System.IO.File.ReadAllText(Server.MapPath("~/BackgroundPicture.html")));
        }
        public JsonResult GetCategories()
        {
            var items = new List<object>();
            var enumType = typeof(Category);
            var values = Enum.GetValues(enumType);
            foreach (var val in values)
            {
                var dispayName = Helpers.EnumHelper.GetDisplayName(enumType, val.ToString());
                items.Add(new { Value = (int)val, DisplayName = dispayName });
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
	}
}