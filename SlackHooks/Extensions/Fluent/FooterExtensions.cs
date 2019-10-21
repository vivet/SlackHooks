using System;
using SlackHooks.Models;

namespace SlackHooks.Extensions.Fluent
{
    /// <summary>
    /// Footer Extensions.
    /// </summary>
    public static class FooterExtensions
    {
        /// <summary>
        /// Set Text.
        /// </summary>
        /// <param name="footer">The <see cref="Footer"/>.</param>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Footer"/>.</returns>
        public static Footer SetText(this Footer footer, string text)
        {
            if (footer == null) 
                throw new ArgumentNullException(nameof(footer));

            footer.Text = text ?? throw new ArgumentNullException(nameof(text));

            return footer;
        }

        /// <summary>
        /// Set Icon Url.
        /// </summary>
        /// <param name="footer">The <see cref="Footer"/>.</param>
        /// <param name="url">The icon url.</param>
        /// <returns>The <see cref="Footer"/>.</returns>
        public static Footer SetIconUrl(this Footer footer, string url)
        {
            if (footer == null) 
                throw new ArgumentNullException(nameof(footer));

            footer.IconUrl = url ?? throw new ArgumentNullException(nameof(url));

            return footer;
        }
    }
}