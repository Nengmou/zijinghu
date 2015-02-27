using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZiJingHu.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<SelectListItem> GetItems(Type enumType, int? selectedValue)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType)) throw new ArgumentException("Type must be an enum.");
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();
            var items = names.Zip(values, (name, value) => 
                new SelectListItem{
                    Text = GetDisplayName(enumType, name),
                    Value = value.ToString(),
                    Selected = (value == selectedValue)
                });
            return items;
        }

        public static string GetDisplayName(Type enumType, string name)
        {
            var attribute = (DisplayAttribute)enumType.GetField(name).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
            return attribute == null ? name : attribute.GetName();
        }
    }
}