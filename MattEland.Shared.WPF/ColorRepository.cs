using System;
using System.Collections.Generic;
using System.Windows.Media;
using JetBrains.Annotations;

namespace MattEland.Shared.WPF
{
    /// <summary>
    /// A common repository for Color parsing operations. When a hex color is interpreted into a Color object,
    /// the value is cached for future conversion efforts.
    /// </summary>
    public static class ColorRepository
    {
        [NotNull]
        private static readonly IDictionary<string, Color> CachedColors = new Dictionary<string, Color>();
        
        /// <summary>
        /// Gets a WPF Color object from a hex color string and stores the translation for future requests.
        /// </summary>
        /// <param name="hexColor">The hex color to use. Sample formats are #00FF00 or #FF00FFCC</param>
        /// <returns>The Color object</returns>
        public static Color GetColorFromHexColor([NotNull] this string hexColor)
        {
            if (hexColor == null) throw new ArgumentNullException(nameof(hexColor));

            // Normalize the hex color for ease of lookup
            hexColor = hexColor.ToUpperInvariant();

            if (CachedColors.ContainsKey(hexColor))
            {
                return CachedColors[hexColor];
            }

            // Perform the color conversion
            var color = (Color?) ColorConverter.ConvertFromString(hexColor) ?? Colors.Transparent;

            // Store it for the next query
            CachedColors[hexColor] = color;
            
            return color;
        }        
    }
}