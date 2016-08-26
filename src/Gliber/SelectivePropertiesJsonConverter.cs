namespace Gliber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using static Newtonsoft.Json.Linq.JObject;

    internal class SelectivePropertiesJsonConverter<TSrc> :JsonConverter
    {
        private readonly IEnumerable<string> selectedProperties;

        public SelectivePropertiesJsonConverter(IEnumerable<string> selectedProperties)
        {
            this.selectedProperties = selectedProperties;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
          
            var jo = FromObject(value);
            // Note: ToList() is needed here to prevent "collection was modified" error
            foreach (var prop in jo.Properties().ToList())
            {
                if (!this.selectedProperties.Contains(prop.Name))
                {
                    prop.Remove();
                }
            }

            jo.WriteTo(writer);
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
           return null;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TSrc);
          // return false;
        }
    }
}