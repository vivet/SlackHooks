using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SlackHook.Extensions.Fluent;
using SlackHook.Models;

namespace Tests.SlackHook
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void MessageTextTest()
        {
            var message = new Message();
            message
                .SetText("test-text");

            Assert.IsNotNull(message);
            Assert.AreEqual("test-text", message.Text);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"text\":\"test-text\",\"mrkdwn\":true,\"attachments\":[]}", json);
        }

        [TestMethod]
        public void MessageTextWhenMarkDownIsFalseTest()
        {
            var message = new Message();
            message
                .SetText("test-text", false);

            Assert.IsNotNull(message);
            Assert.AreEqual("test-text", message.Text);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"text\":\"test-text\",\"mrkdwn\":false,\"attachments\":[]}", json);
        }

        [TestMethod]
        public void MessageUsernameTest()
        {
            var message = new Message();
            message
                .SetText("test-text")
                .SetUsername("test-user");

            Assert.IsNotNull(message);
            Assert.AreEqual("test-text", message.Text);
            Assert.AreEqual("test-user", message.Username);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"text\":\"test-text\",\"username\":\"test-user\",\"mrkdwn\":true,\"attachments\":[]}", json);
        }

        [TestMethod]
        public void MessageAttachmentTextTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text"));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"color\":\"#FFFFFF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }
        
        [TestMethod]
        public void MessageAttachmentPreTextTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text")
                    .SetPreText("test-attachment-pretext"));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);
            Assert.AreEqual("test-attachment-pretext", attachment.PreText);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"pretext\":\"test-attachment-pretext\",\"color\":\"#FFFFFF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }

        [TestMethod]
        public void MessageAttachmentFallbackTextTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text")
                    .SetFallbackText("test-attachment-fallback"));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);
            Assert.AreEqual("test-attachment-fallback", attachment.FallbackText);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"fallback\":\"test-attachment-fallback\",\"color\":\"#FFFFFF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }

        [TestMethod]
        public void MessageAttachmentImageUrlTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text")
                    .SetImageUrl("test-attachment-image-url"));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);
            Assert.AreEqual("test-attachment-image-url", attachment.ImageUrl);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"image_url\":\"test-attachment-image-url\",\"color\":\"#FFFFFF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }

        [TestMethod]
        public void MessageAttachmentThumbUrlTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text")
                    .SetThumbUrl("test-attachment-thumb-url"));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);
            Assert.AreEqual("test-attachment-thumb-url", attachment.ThumbUrl);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"thumb_url\":\"test-attachment-thumb-url\",\"color\":\"#FFFFFF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }

        [TestMethod]
        public void MessageAttachmentColorTest()
        {
            var message = new Message();
            message
                .AddAttachment(x => x
                    .SetText("test-attachment-text")
                    .SetColor(Color.AliceBlue));

            var attachment = message.Attachments.FirstOrDefault();

            Assert.IsNotNull(attachment);
            Assert.AreEqual("test-attachment-text", attachment.Text);
            Assert.AreEqual(Color.AliceBlue, attachment.Color);
            Assert.AreEqual("#F0F8FF", attachment.HexColor);

            var json = JsonConvert.SerializeObject(message, global::SlackHook.SlackClient.jsonSerializerSettings);

            Assert.IsNotNull(json);
            Assert.AreEqual("{\"mrkdwn\":true,\"attachments\":[{\"text\":\"test-attachment-text\",\"color\":\"#F0F8FF\",\"ts\":0,\"mrkdwn_in\":[\"text\"],\"fields\":[]}]}", json);
        }

        [TestMethod]
        public void MessageAttachmentTitleTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MessageAttachmentAuthorTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MessageAttachmentFooterTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MessageAttachmentTimeStampTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MessageAttachmentFieldsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MessageAttachmentTableTest()
        {
            Assert.Inconclusive();
        }
    }
}
