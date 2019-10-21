using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackHooks;
using SlackHooks.Extensions.Fluent;
using SlackHooks.Models;

namespace Tests.SlackHooks
{
    [TestClass]
    public class IntegrationTests
    {
        public virtual string WebhookUrl => "";

        [TestMethod]
        public void MessageTest()
        {
            var message = new Message();
            message
                .SetChannel("BPDTC9K55/ZsJ2JuFWM6sEb6ronODNXg5n")
                .SetText("test-text");

            var client = new SlackClient(new Uri(this.WebhookUrl));

            var result = client
                .SendMessageAsync(message).Result;

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public void MessageAttachmentTest()
        {
            var message = new Message();
            message
                .SetChannel("BPDTC9K55/ZsJ2JuFWM6sEb6ronODNXg5n")
                .AddAttachment(x => x
                    .SetTitle(y => y
                        .SetText("test-title")
                        .SetLinkUrl("https://slack.com"))
                    .SetText("test-text")
                    .SetAuthor(y => y
                        .SetName("test-auhtor")
                        .SetLinkUrl("http://slack.com")
                        .SetIconUrl("https://platform.slack-edge.com/img/default_application_icon.png"))
                    .SetFallbackText("falback-text")
                    .SetColor(Color.Green)
                    .SetImageUrl("https://platform.slack-edge.com/img/default_application_icon.png")
                    .SetThumbUrl("https://platform.slack-edge.com/img/default_application_icon.png")
                    .SetFooter(y => y
                        .SetText("text-footer")
                        .SetIconUrl("https://platform.slack-edge.com/img/default_application_icon.png")));

            var client = new SlackClient(new Uri(this.WebhookUrl));

            var result = client
                .SendMessageAsync(message).Result;

            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}