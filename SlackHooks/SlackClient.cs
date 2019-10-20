using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlackHooks.Models;
using SlackHooks.Serialization.Resolvers;

namespace SlackHooks
{
    /// <summary>
    /// Slack Client.
    /// Posts a text to a Slack Channel through a webhook url configured in the Slack App.
    /// Reference: https://api.slack.com/docs
    /// </summary>
    public class SlackClient : IDisposable
    {
        private readonly Uri webhookUrl;
        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Json Serializer Settings.
        /// </summary>
        protected internal static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings 
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
            ContractResolver = new LowerCaseContractResolver()
        };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="webhookUrl">The webhook url, configured in the Slack App.</param>
        public SlackClient(Uri webhookUrl)
        {
            this.webhookUrl = webhookUrl ?? throw new ArgumentNullException(nameof(webhookUrl));
        }

        /// <summary>
        /// Send Message Async.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <returns>The response.</returns>
        public async Task<HttpResponseMessage> SendMessageAsync(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var json = JsonConvert.SerializeObject(message, SlackClient.jsonSerializerSettings);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await this.httpClient
                    .PostAsync(this.webhookUrl, content);

                return response;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}
