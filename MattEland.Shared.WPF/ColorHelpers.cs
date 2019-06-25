using System;
using System.Collections.Generic;
using System.Windows.Media;
using JetBrains.Annotations;

namespace MattEland.Shared.WPF
{
    /// <summary>
    /// A common repository for Color parsing operations. When a hex foregroundColor is interpreted into a Color object,
    /// the value is cached for future conversion efforts.
    /// </summary>
    public static class ColorHelpers
    {
        [NotNull]
        private static readonly IDictionary<string, Color> CachedColors = new Dictionary<string, Color>();
        
        /// <summary>
        /// Gets a WPF Color object from a hex foregroundColor string and stores the translation for future requests.
        /// </summary>
        /// <param name="hexColor">The hex foregroundColor to use. Sample formats are #00FF00 or #FF00FFCC</param>
        /// <returns>The Color object</returns>
        public static Color GetColorFromHexColor([NotNull] this string hexColor)
        {
            if (hexColor == null) throw new ArgumentNullException(nameof(hexColor));

            // Normalize the hex foregroundColor for ease of lookup
            hexColor = hexColor.ToUpperInvariant();

            if (CachedColors.ContainsKey(hexColor))
            {
                return CachedColors[hexColor];
            }

            // Perform the foregroundColor conversion
            var color = (Color?) ColorConverter.ConvertFromString(hexColor) ?? Colors.Transparent;

            // Store it for the next query
            CachedColors[hexColor] = color;
            
            return color;
        }        

        /// <summary>Blends the specified colors together.</summary>
        /// <param name="foregroundColor">Color to blend onto the background foregroundColor.</param>
        /// <param name="backColor">Color to blend the other foregroundColor onto.</param>
        /// <param name="percent">How much of <paramref name="foregroundColor"/> to keep,
        /// “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        [UsedImplicitly]
        public static Color Blend(this Color foregroundColor, Color backColor, double percent)
        {
            var r = BlendColorChannel(foregroundColor.R, backColor.R, percent);
            var g = BlendColorChannel(foregroundColor.G, backColor.G, percent);
            var b = BlendColorChannel(foregroundColor.B, backColor.B, percent);

            return Color.FromArgb(backColor.A, r, g, b);
        }

        private static byte BlendColorChannel(byte foregroundValue, byte backgroundValue, double percent) 
            => (byte) ((foregroundValue * percent) + backgroundValue * (1 - percent));
    }
}