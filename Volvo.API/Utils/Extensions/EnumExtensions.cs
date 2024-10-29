using System.ComponentModel;
using System.Reflection;

namespace Volvo.API.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var member = enumType.GetMember(enumValue.ToString()).FirstOrDefault();

            if (member != null)
            {
                var descriptionAttribute = member.GetCustomAttribute<DescriptionAttribute>();

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return enumValue.ToString();
        }
    }
}
