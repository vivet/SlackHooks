﻿using System;
using SlackHooks.Models;

namespace SlackHooks.Extensions.Fluent
{
    /// <summary>
    /// Message Extensions.
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        /// Set Channel.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <param name="channel">The channel path of the webhook url.</param>
        /// <returns>The <see cref="Message"/>.</returns>
        public static Message SetChannel(this Message message, string channel)
        {
            if (message == null) 
                throw new ArgumentNullException(nameof(message));

            message.Channel = channel ?? throw new ArgumentNullException(nameof(channel));

            return message;
        }

        /// <summary>
        /// Set Text.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <param name="text">The text.</param>
        /// <param name="useMarkdown">Use markdown format.</param>
        /// <returns>The <see cref="Message"/>.</returns>
        public static Message SetText(this Message message, string text, bool useMarkdown = true)
        {
            if (message == null) 
                throw new ArgumentNullException(nameof(message));

            message.Text = text;
            message.UseMarkdown = useMarkdown;

            return message;
        }

        /// <summary>
        /// Set Username.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <param name="username">The username.</param>
        /// <returns>The <see cref="Message"/>.</returns>
        public static Message SetUsername(this Message message, string username)
        {
            if (message == null) 
                throw new ArgumentNullException(nameof(message));

            message.Username = username;
 
            return message;
        }

        /// <summary>
        /// Add Attachment.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <param name="selctor">The <see cref="Attachment"/> selector.</param>
        /// <returns>The <see cref="Message"/>.</returns>
        public static Message AddAttachment(this Message message, Func<Attachment, Attachment> selctor)
        {
            if (message == null) 
                throw new ArgumentNullException(nameof(message));
           
            var attachment = new Attachment();

            attachment = selctor
                .Invoke(attachment);

            message.Attachments
                .Add(attachment);

            return message;
        }
    }
}