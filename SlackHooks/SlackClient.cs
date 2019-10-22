using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
        private static HttpClient httpClient;
        private static readonly TimeSpan httpTimeout = new TimeSpan(0, 0, 30);

        /// <summary>
        /// Http Client.
        /// </summary>
        protected internal static HttpClient HttpClient
        {
            get
            {
                if (SlackClient.httpClient == null)
                {
                    var httpClientHandler = new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    };

                    SlackClient.httpClient = new HttpClient(httpClientHandler)
                    {
                        Timeout = SlackClient.httpTimeout
                    };

                    SlackClient.httpClient.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return SlackClient.httpClient;
            }
            set
            {
                SlackClient.httpClient = value;
            }
        }

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
        /// Send Async.
        /// </summary>
        /// <param name="message">The <see cref="Message"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The response.</returns>
        public async Task<HttpResponseMessage> SendAsync(Message message, CancellationToken cancellationToken = default)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var uri = new Uri(this.baseUri, message.Channel);
            var json = JsonConvert.SerializeObject(message, SlackClient.jsonSerializerSettings);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await SlackClient.HttpClient
                    .PostAsync(uri, content, cancellationToken);

                return response;
            }
        }

        /// <summary>
        /// Disposes.
        /// </summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the <see cref="HttpClient"/>, if <paramref name="disposing"/> is true.
        /// </summary>
        /// <param name="disposing">Whether to dispose resources or not.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            SlackClient.HttpClient?.Dispose();
            SlackClient.httpClient = null;
        }
    }
}
