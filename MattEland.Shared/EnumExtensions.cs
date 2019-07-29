using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace MattEland.Shared
{
    /// <summary>
    /// A collection of extension methods for working with enumerated types.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the name of the enum value from the System.ComponentModel.DataAnnotations.Display attribute's Name, or uses the default ToString implementation.
        /// </summary>
        /// <param name="enumValue">The enum value to parse</param>
        /// <returns>The string representation of the enum value</returns>
        [CanBeNull]
        public static string GetDisplayName(this Enum enumValue)
        {
            var attr = enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>();

            return attr != null ? attr.GetName() : enumValue.ToString("G");
        }
    }
}