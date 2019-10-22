using System;
using SlackHooks.Models;

namespace SlackHooks.Extensions.Fluent
{
    /// <summary>
    /// Author Extensions.
    /// </summary>
    public static class AuthorExtensions
    {
        /// <summary>
        /// Set Name.
        /// </summary>
        /// <param name="author">The <see cref="Author"/>.</param>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="Author"/>.</returns>
        public static Author SetName(this Author author, string name)
        {
            if (author == null) 
                throw new ArgumentNullException(nameof(author));

            author.Name = name;

            return author;
        }

        /// <summary>
        /// Set Link Url.
        /// </summary>
        /// <param name="author">The <see cref="Author"/>.</param>
        /// <param name="url">The image url.</param>
        /// <returns>The <see cref="Author"/>.</returns>
        public static Author SetLinkUrl(this Author author, string url)
        {
            if (author == null) 
                throw new ArgumentNullException(nameof(author));

            author.LinkUrl = url;

            return author;
        }

        /// <summary>
        /// Set Icon Url.
        /// </summary>
        /// <param name="author">The <see cref="Author"/>.</param>
        /// <param name="url">The icon url.</param>
        /// <returns>The <see cref="Author"/>.</returns>
        public static Author SetIconUrl(this Author author, string url)
        {
            if (author == null) 
                throw new ArgumentNullException(nameof(author));

            author.IconUrl = url;

            return author;
        }
    }
}