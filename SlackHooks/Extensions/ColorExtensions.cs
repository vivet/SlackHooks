using System.Drawing;

namespace SlackHooks.Extensions
{
    /// <summary>
    /// Color Extensions
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts Color to hex value.
        /// </summary>
        /// <param name="color">The <see cref="Color"/>.</param>
        /// <returns>The converted <see cref="Color"/>.</returns>
        public static string ToHex(this Color color)
        {
            var red = color.R.ToString("X2");
            var green = color.G.ToString("X2");
            var blue = color.B.ToString("X2");

            return $"#{red}{green}{blue}";
        }
    }
}