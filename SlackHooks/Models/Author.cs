namespace SlackHooks.Models
{
    /// <summary>
    /// Author.
    /// The author parameters will display a small section at the top of a message attachment 
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Name.
        /// Small text used to display the author's name.
        /// </summary>
        public virtual string Name { get; protected internal set; }

        /// <summary>
        /// Icon Url.
        /// A valid URL that will hyperlink the author_name text mentioned above.
        /// Will only work if author_name is present.
        /// </summary>
        public virtual string IconUrl { get; protected internal set; }

        /// <summary>
        /// Link Url.
        /// A valid URL that displays a small 16x16px image to the left of the author_name text.
        /// Will only work if author_name is present.
        /// </summary>
        public virtual string LinkUrl { get; protected internal set; }
    }
}