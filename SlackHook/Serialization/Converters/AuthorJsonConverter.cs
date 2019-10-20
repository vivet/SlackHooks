using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackHook.Models;

namespace SlackHook.Serialization.Converters
{
    /// <summary>
    /// Author Json Converter.
    /// </summary>
    public class AuthorJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            if (objectType == null) 
                throw new ArgumentNullException(nameof(objectType));

            return objectType == typeof(Author);
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null) 
                throw new ArgumentNullException(nameof(writer));

            if (value is Author author)
            {
                var obj = JObject.FromObject(value, serializer);
                var property = obj.Children<JProperty>().FirstOrDefault(z => z.Name == nameof(Author).ToLower());

                if (property != null)
                {
                    property
                        .AddAfterSelf(new JProperty("author_name", author.Name));
                    
                    property
                        .AddAfterSelf(new JProperty("author_link", author.LinkUrl));
                    
                    property
                        .AddAfterSelf(new JProperty("author_icon", author.IconUrl));
                    
                    property
                        .Remove();
                }

                serializer
                    .Serialize(writer, obj);
            }
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}