using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ForeignKeyConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType.GetGenericTypeDefinition() == typeof(List<>);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            IList collection = (IList)value;

            writer.WriteStartArray();
            foreach (var v in collection) {
                writer.WriteValue(GetId(v));
            }
            
            writer.WriteEndArray();
        }

        private string GetId(object obj) {
            PropertyInfo prop = obj.GetType().GetProperty("Key", typeof(string));
            if (prop != null && prop.CanRead) {
                return (string)prop.GetValue(obj, null);
            }
            return null;
        }

        public override bool CanRead { get { return false; } }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
