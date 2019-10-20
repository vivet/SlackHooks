namespace SlackHooks.Models
{
    /// <summary>
    /// Title.
    /// The title is displayed as larger, bold text near the top of a message attachment.
    /// </summary>
    public class Title
    {
        /// <summary>
        /// Text.
        /// The title text.
        /// </summary>
        public virtual string Text { get; set; }
        
        /// <summary>
        /// Link Url.
        /// The valid URL title text will be hyperlinked.
        /// </summary>
        public virtual string LinkUrl { get; set; }
    }
}