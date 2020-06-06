using System;
using System.Linq;
using System.Runtime.Serialization;

namespace AP.Constantine.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }

            return default;
        }
    }
}
