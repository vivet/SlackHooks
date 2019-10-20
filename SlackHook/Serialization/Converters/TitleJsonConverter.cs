using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackHook.Models;

namespace SlackHook.Serialization.Converters
{
    /// <summary>
    /// Title Json Converter.
    /// </summary>
    public class TitleJsonConverter : JsonConverter
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

            if (value is Title title)
            {
                var obj = JObject.FromObject(value, serializer);
                var property = obj.Children<JProperty>().FirstOrDefault(x => x.Name == nameof(Title).ToLower());
                
                if (property != null)
                {
                    property.Value = title.Text;
                    
                    if (title.LinkUrl != null)
                    {
                        property
                            .AddAfterSelf(new JProperty("title_link", title.LinkUrl));
                    }
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