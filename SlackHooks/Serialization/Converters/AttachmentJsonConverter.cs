using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackHooks.Models;

namespace SlackHooks.Serialization.Converters
{
    /// <summary>
    /// Title Json Converter.
    /// </summary>
    public class AttachmentJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));

            return objectType == typeof(Title);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));


            var objectToken = JToken.FromObject(value, serializer);
            var obj = (JObject)objectToken;

            if (value is Attachment attachment)
            {
                var titleProperty = obj.Children<JProperty>()
                    .FirstOrDefault(x => x.Name == "title");
                
                if (titleProperty != null && attachment.Title != null)
                {
                    titleProperty.Value = attachment.Title.Text;
                    if (attachment.Title.LinkUrl != null)
                    {
                        titleProperty
                            .AddAfterSelf(new JProperty("title_link", attachment.Title.LinkUrl));
                    }
                }

                var authorProperty = obj.Children<JProperty>()
                    .FirstOrDefault(z => z.Name == "author");

                if (authorProperty != null && attachment.Author != null)
                {
                    authorProperty
                        .AddAfterSelf(new JProperty("author_name", attachment.Author.Name));
                    
                    authorProperty
                        .AddAfterSelf(new JProperty("author_link", attachment.Author.LinkUrl));
                    
                    authorProperty
                        .AddAfterSelf(new JProperty("author_icon", attachment.Author.IconUrl));
                    
                    authorProperty
                        .Remove();
                }

                var footerProperty = obj.Children<JProperty>()
                    .FirstOrDefault(x => x.Name == "footer");
                
                if (footerProperty != null && attachment.Footer != null)
                {
                    footerProperty.Value = attachment.Footer.Text;
                    if (attachment.Footer.IconUrl != null)
                    {
                        footerProperty
                            .AddAfterSelf(new JProperty("footer_icon", attachment.Footer.IconUrl));
                    }
                }
            }

            serializer
                .Serialize(writer, obj);
            
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}