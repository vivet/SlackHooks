namespace SlackHooks.Models
{
    /// <summary>
    /// Footer.
    /// Add some brief text to help contextualize and identify an attachment.
    /// Limited to 300 characters, and may be truncated further when displayed to users in environments with limited screen real estate.
    /// </summary>
    public class Footer
    {
        /// <summary>
        /// Text.
        /// The footer text.
        /// </summary>
        public virtual string Text { get; protected internal set; }
        
        /// <summary>
        /// Icon Url.
        /// To render a small icon beside your footer text, provide a publicly accessible URL string in the footer_icon field.
        /// You must also provide a footer for the field to be recognized.
        /// We'll render what you provide at 16px by 16px. It's best to use an image that is similarly sized.
        /// </summary>
        public virtual string IconUrl { get; protected internal set; }
    }
}