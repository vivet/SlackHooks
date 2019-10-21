using System.Collections.Generic;
using Newtonsoft.Json;
using SlackHooks.Serialization.Converters;

namespace SlackHooks.Models
{
    /// <summary>
    /// Message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Channel.
        /// The channel identifier of the webhook path.
        /// </summary>
        [JsonIgnore]
        public virtual string Channel { get; protected internal set; }

        /// <summary>
        /// Text.
        /// A simple text.
        /// </summary>
        public virtual string Text { get; protected internal set; }
        
        /// <summary>
        /// Username.
        /// The username of the one posting (optional)
        /// </summary>
        public virtual string Username { get; protected internal set; }

        /// <summary>
        /// Use Markdown (default: true).
        /// </summary>
        [JsonProperty("mrkdwn")]
        public virtual bool UseMarkdown { get; protected internal set; } = true;
        
        /// <summary>
        /// Attachments.
        /// Attachments can be added to messages in different ways:
        /// - For Incoming Webhooks, send a regular payload, but include an attachments array, where each element is a hash containing an attachment.
        /// - For the Web API, include an attachments URL parameter, or send your message as application/json just as you would with an incoming webhook.
        /// Please limit your messages to contain no more than 20 attachments to provide the best user experience.
        /// </summary>
        [JsonProperty(ItemConverterType = typeof(AttachmentJsonConverter))]
        public virtual IList<Attachment> Attachments { get; protected set; } = new List<Attachment>();
    }
}