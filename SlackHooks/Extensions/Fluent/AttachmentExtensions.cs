using System;
using System.Drawing;
using SlackHooks.Enums;
using SlackHooks.Models;

namespace SlackHooks.Extensions.Fluent
{
    /// <summary>
    /// Attachment Extensions.
    /// </summary>
    public static class AttachmentExtensions
    {
        /// <summary>
        /// Set Text.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="text">The text.</param>
        /// <param name="useMarkdown">Use markdown format.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetText(this Attachment attachment, string text, bool useMarkdown = true)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.Text = text;

            if (useMarkdown)
                attachment.MarkDown |= MarkDownType.Text;

            return attachment;
        }
        
        /// <summary>
        /// Set Title.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="selctor">The <see cref="Title"/> selector.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetTitle(this Attachment attachment, Func<Title, Title> selctor)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));
           
            var title = new Title();

            attachment.Title = selctor
                .Invoke(title);

            return attachment;
        }
        
        /// <summary>
        /// Set Author.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="selctor">The <see cref="Author"/> selector.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetAuthor(this Attachment attachment, Func<Author, Author> selctor)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));
           
            var footer = new Author();

            attachment.Author = selctor
                .Invoke(footer);

            return attachment;
        }

        /// <summary>
        /// Set Footer.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="selctor">The <see cref="Footer"/> selector.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetFooter(this Attachment attachment, Func<Footer, Footer> selctor)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));
           
            var footer = new Footer();

            attachment.Footer = selctor
                .Invoke(footer);

            return attachment;
        }

        /// <summary>
        /// Set Pre-Text.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="text">The pre-text.</param>
        /// <param name="useMarkdown">Use markdown format.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetPreText(this Attachment attachment, string text, bool useMarkdown = false)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.PreText = text;

            if (useMarkdown)
                attachment.MarkDown |= MarkDownType.Pretext;

            return attachment;
        }

        /// <summary>
        /// Set Fallback Text.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="text">The fallback text.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetFallbackText(this Attachment attachment, string text)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.FallbackText = text;

            return attachment;
        }

        /// <summary>
        /// Set Image Url.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="url">The image url.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetImageUrl(this Attachment attachment, string url)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.ImageUrl = url;

            return attachment;
        }
        
        /// <summary>
        /// Set Thumb Url.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="url">The thumb url.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetThumbUrl(this Attachment attachment, string url)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.ThumbUrl = url;

            return attachment;
        }

        /// <summary>
        /// Set Color (left-bar).
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="color">The <see cref="Color"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetColor(this Attachment attachment, Color color)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.Color = color;

            return attachment;
        }

        /// <summary>
        /// Set Time-Stamp.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="timestamp">The <see cref="DateTime"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetTimestamp(this Attachment attachment, DateTime? timestamp = null)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            timestamp = timestamp ?? DateTime.UtcNow;

            attachment.TimeStamp = timestamp.Value.DateTimeToUnixTimestamp();

            return attachment;
        }

        /// <summary>
        /// Add Table.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="table">The <see cref="Table"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment AddTable(this Attachment attachment, Table table)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            if (table == null) 
                throw new ArgumentNullException(nameof(table));

            table.Columns
                .ForEach(x =>
                {
                    var value = string.Empty;

                    foreach (var row in x.Fields)
                    {
                        value += row.Title + "\n";
                    }
                    value = value.TrimEnd('\n');

                    var header = new Field
                    {
                        Title = x.Name,
                        Value = value,
                        Short = true
                    };
                    
                    attachment
                        .AddField(header);
                });
            return attachment;
        }

        /// <summary>
        /// Add Field.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="field">The <see cref="Field"/>.</param>
        /// <param name="useMarkdown">Use markdown format.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment AddField(this Attachment attachment, Field field, bool useMarkdown = false)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            if (field == null) 
                throw new ArgumentNullException(nameof(field));

            attachment.Fields
                .Add(field);

            if (useMarkdown)
                attachment.MarkDown |= MarkDownType.Fields;

            return attachment;
        }
    }
}