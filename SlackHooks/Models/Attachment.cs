using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using SlackHooks.Enums;
using SlackHooks.Extensions;

namespace SlackHooks.Models
{
    /// <summary>
    /// Attachment.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Text.
        /// Optional text that appears within the attachment.
        /// This is the main text in a message attachment, and can contain standard message markup.
        /// The content will automatically collapse if it contains 700+ characters or 5+ linebreaks, and will display a "Show more..." link to expand the content.
        /// Links posted in the text field will not unfurl.
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// Pre Text.
        /// This is optional text that appears above the message attachment block.
        /// </summary>
        public virtual string PreText { get; set; }

        /// <summary>
        /// Fallback Text.
        /// A plain-text summary of the attachment. This text will be used in clients,
        /// that don't show formatted text (eg. IRC, mobile notifications) and should not contain any markup.
        /// </summary>
        [JsonProperty("fallback")]
        public virtual string FallbackText { get; protected internal set; }

        /// <summary>
        /// Image Url.
        /// A valid URL to an image file that will be displayed inside a message attachment.
        /// We currently support the following formats: GIF, JPEG, PNG, and BMP.
        /// Large images will be resized to a maximum width of 360px or a maximum height of 500px, while still maintaining the original aspect ratio.
        /// </summary>
        [JsonProperty("image_url")]
        public virtual string ImageUrl { get; set; }

        /// <summary>
        /// Thumb Url.
        /// A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment.
        /// We currently support the following formats: GIF, JPEG, PNG, and BMP.
        /// The thumbnail's longest dimension will be scaled down to 75px while maintaining the aspect ratio of the image.
        /// The filesize of the image must also be less than 500 KB.
        /// For best results, please use images that are already 75px by 75px.
        /// </summary>
        [JsonProperty("thumb_url")]
        public virtual string ThumbUrl { get; set; }

        /// <summary>
        /// Color.
        /// Like traffic signals, color-coding messages can quickly communicate intent and help separate them from the flow of other messages in the timeline.
        /// An optional value that can either be one of good, warning, danger, or any hex color code (eg. #439FE0).
        /// This value is used to color the border along the left side of the message attachment.
        /// </summary>
        [JsonIgnore]
        public virtual Color Color { get; protected internal set; } = Color.Transparent;
        
        /// <summary>
        /// The <see cref="Color"/> represented as Hex value.
        /// </summary>
        [JsonProperty("color")]
        protected internal virtual string HexColor => this.Color.ToHex();

        /// <summary>
        /// Title.
        /// The title is displayed as larger, bold text near the top of a message attachment.
        /// By passing a valid URL in the title_link parameter (optional), the title text will be hyperlinked.
        /// </summary>
        public virtual Title Title { get; set; }

        /// <summary>
        /// Author.
        /// The author parameters will display a small section at the top of a message attachment 
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// Footer.
        /// Your message attachments may also contain a subtle footer,
        /// which is especially useful when citing content in conjunction with author parameters.
        /// </summary>
        public virtual Footer Footer { get; set; }

        /// <summary>
        /// Time Stamp.
        /// Does your attachment relate to something happening at a specific time?
        /// By providing the ts field with an integer value in "epoch time",
        /// the attachment will display an additional timestamp value as part of the attachment's footer.
        /// </summary>
        [JsonProperty("ts")]
        public virtual int TimeStamp { get; set; }

        /// <summary>
        /// Markdown.
        /// The markdown definitions.
        /// </summary>
        [JsonIgnore]
        public virtual MarkDownType MarkDown { get; set; } = MarkDownType.None;

        /// <summary>
        /// Mark Down List.
        /// The <see cref="MarkDown"/> converted to list for each flag.
        /// </summary>
        [JsonProperty("mrkdwn_in")]
        protected internal virtual IList<string> MarkDownList
        {
            get
            {
                var markdownFields = new List<string>();

                if (this.MarkDown.HasFlag(MarkDownType.Text))
                    markdownFields.Add("text");
            
                if (this.MarkDown.HasFlag(MarkDownType.Pretext))
                    markdownFields.Add("pretext");

                if (this.MarkDown.HasFlag(MarkDownType.Fields))
                    markdownFields.Add("fields");

                return markdownFields;
            }
        }
        
        /// <summary>
        /// Fields.
        /// Fields are defined as an array. Each entry in the array is a single field.
        /// Each field is defined as a dictionary with key-value pairs. Fields get displayed in a table-like way
        /// For best results, include no more than 2-3 key/value pairs.
        /// There is no optimal, programmatic way to display a greater amount of tabular data on Slack today
        /// </summary>
        public virtual List<Field> Fields { get; protected set; } = new List<Field>();
    }
}