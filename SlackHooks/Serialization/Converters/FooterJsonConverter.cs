using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackHooks.Models;

namespace SlackHooks.Serialization.Converters
{
    /// <summary>
    /// Footer Json Converter.
    /// </summary>
    public class FooterJsonConverter : JsonConverter
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

            if (value is Footer footer)
            {
                var obj = JObject.FromObject(value, serializer);
                var property = obj.Children<JProperty>().FirstOrDefault(x => x.Name == nameof(Footer).ToLower());
                
                if (property != null)
                {
                    property.Value = footer.Text;
                    
                    if (footer.IconkUrl != null)
                    {
                        property
                            .AddAfterSelf(new JProperty("footer_icon", footer.IconkUrl));
                    }
                }

                serializer.Serialize(writer, obj);
            }
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}