using System;
using System.Drawing;
using SlackHook.Enums;
using SlackHook.Models;

namespace SlackHook.Extensions.Fluent
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

            attachment.Text = text ?? throw new ArgumentNullException(nameof(text));

            if (useMarkdown)
                attachment.MarkDown |= MarkDownType.Text;

            return attachment;
        }

        /// <summary>
        /// Set Title.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="title">The <see cref="Title"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetTitle(this Attachment attachment, Title title)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));
           
            attachment.Title = title ?? throw new ArgumentNullException(nameof(title));

            return attachment;
        }

        /// <summary>
        /// Set Author.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="author">The <see cref="Author"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetAuthor(this Attachment attachment, Author author)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));

            attachment.Author = author ?? throw new ArgumentNullException(nameof(author));

            return attachment;
        }

        /// <summary>
        /// Set Footer.
        /// </summary>
        /// <param name="attachment">The <see cref="Attachment"/>.</param>
        /// <param name="footer">The <see cref="Footer"/>.</param>
        /// <returns>The <see cref="Attachment"/>.</returns>
        public static Attachment SetFooter(this Attachment attachment, Footer footer)
        {
            if (attachment == null) 
                throw new ArgumentNullException(nameof(attachment));
           
            attachment.Footer = footer ?? throw new ArgumentNullException(nameof(footer));

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

            attachment.PreText = text ?? throw new ArgumentNullException(nameof(text));

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

            attachment.FallbackText = text ?? throw new ArgumentNullException(nameof(text));

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

            attachment.ImageUrl = url ?? throw new ArgumentNullException(nameof(url));

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

            attachment.ThumbUrl = url ?? throw new ArgumentNullException(nameof(url));

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

            attachment.Fields
                .Add(field);

            if (useMarkdown)
                attachment.MarkDown |= MarkDownType.Fields;

            return attachment;
        }
    }
}