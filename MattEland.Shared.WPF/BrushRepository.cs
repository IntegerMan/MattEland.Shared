using System;
using System.Collections.Generic;
using System.Windows.Media;
using JetBrains.Annotations;

namespace MattEland.Shared.WPF
{
    /// <summary>
    /// A common repository for creating and storing SolidColorBrush instances for a given hex color and minimizing the number
    /// of brushes that must be created by recycling the same brushes for identical colors.
    /// </summary>
    [UsedImplicitly]
    public static class BrushRepository
    {
        [NotNull]
        private static readonly IDictionary<Color, Brush> CachedBrushes = new Dictionary<Color, Brush>();

        /// <summary>
        /// Gets a SolidColorBrush for use with the given hex color
        /// </summary>
        /// <param name="hexColor">The hex color to use. Sample formats are #00FF00 or #FF00FFCC</param>
        /// <returns>The newly-created brush</returns>
        [UsedImplicitly, NotNull]
        public static Brush GetBrushForHexColor([NotNull] this string hexColor)
        {
            if (hexColor == null) throw new ArgumentNullException(nameof(hexColor));

            hexColor = hexColor.ToUpperInvariant();
            var color = GetColorFromHexColor(hexColor);

            return GetBrushForColor(color);
        }

        /// <summary>
        /// Gets a SolidColorBrush for use with the given Color
        /// </summary>
        /// <param name="color">The Color to use</param>
        /// <returns>The newly-created brush</returns>
        [NotNull]
        public static Brush GetBrushForColor(Color color)
        {
            if (CachedBrushes.ContainsKey(color))
            {
                return CachedBrushes[color];
            }

            var brush = BuildBrushForColor(color);

            CachedBrushes[color] = brush;

            return brush;
        }

        private static SolidColorBrush BuildBrushForColor(Color color)
        {
            SolidColorBrush brush;

            if (color.A == 0)
            {
                brush = Brushes.Transparent;
            }
            else
            {
                brush = new SolidColorBrush(color);
                brush.Freeze();
            }

            return brush;
        }

        private static Color GetColorFromHexColor(string hexColor) 
            => (Color?) ColorConverter.ConvertFromString(hexColor) ?? Colors.Transparent;
    }
}