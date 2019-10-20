namespace SlackHooks.Models
{
    /// <summary>
    /// Field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Title.
        /// Shown as a bold heading above the value text.
        /// It cannot contain markup and will be escaped for you.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Value.
        /// The text value of the field. 800 characters is the maximum length.
        /// Value may contain standard message markup and must be escaped as normal.
        /// May be multi-line.
        /// </summary>
        public virtual string Value { get; set; }
        
        /// <summary>
        /// Short.
        /// An optional flag indicating whether the value is short enough to be displayed side-by-side with other values.
        /// </summary>
        public virtual bool Short { get; set; }
    }
}