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
        private readonly Uri baseUri;
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
        /// <param name="baseUri">The base part of the webhook url, configured in the Slack App.</param>
        public SlackClient(Uri baseUri)
        {
            this.baseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));

            if (!this.baseUri.OriginalString.EndsWith("/"))
            {
                this.baseUri = new Uri($"{this.baseUri.OriginalString}/");
            }
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

            var uri = new Uri(this.baseUri, message.Channel);
            var json = JsonConvert.SerializeObject(message, SlackClient.jsonSerializerSettings);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await this.httpClient
                    .PostAsync(uri, content);

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
