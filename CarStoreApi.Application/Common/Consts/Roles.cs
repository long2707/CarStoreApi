using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.Common.Consts
{
    public enum Roles
    {
        [Description("Administrator")]
        Admin,

        [Description("Regular User")]
        User,

        [Description("Content Moderator")]
        Moderator,

        [Description("Guest User")]
        Guest
    }

    // Extension method to get the string value
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
