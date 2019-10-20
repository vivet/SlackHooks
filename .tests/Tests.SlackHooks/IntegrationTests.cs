using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                .SetText("test-text");

            var client = new global::SlackHooks.SlackClient(new Uri(this.WebhookUrl));

            var result = client
                .SendMessageAsync(message).Result;

            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public void MessageAttachmentTest()
        {
            Assert.Inconclusive();
        }
    }
}