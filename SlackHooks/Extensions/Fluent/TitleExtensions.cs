using System;
using SlackHooks.Models;

namespace SlackHooks.Extensions.Fluent
{
    /// <summary>
    /// Title Extensions.
    /// </summary>
    public static class TitleExtensions
    {
        /// <summary>
        /// Set Text.
        /// </summary>
        /// <param name="title">The <see cref="Title"/>.</param>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Title"/>.</returns>
        public static Title SetText(this Title title, string text)
        {
            if (title == null) 
                throw new ArgumentNullException(nameof(title));

            title.Text = text;

            return title;
        }

        /// <summary>
        /// Set Link Url.
        /// </summary>
        /// <param name="title">The <see cref="Title"/>.</param>
        /// <param name="url">The image url.</param>
        /// <returns>The <see cref="Title"/>.</returns>
        public static Title SetLinkUrl(this Title title, string url)
        {
            if (title == null) 
                throw new ArgumentNullException(nameof(title));

            title.LinkUrl = url;

            return title;
        }
    }
}