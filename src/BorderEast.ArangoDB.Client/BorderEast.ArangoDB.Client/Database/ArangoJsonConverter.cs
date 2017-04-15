using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ArangoJsonConverter : JsonConverter {
        private readonly Type[] _types;
        public ArangoJsonConverter(params Type[] types)
        {
            _types = types;
        }
    public override bool CanConvert(Type objectType) {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            JToken t = JToken.FromObject(value);
            var property = value.GetType().GetProperty("Username");
            foreach(var attr in property.CustomAttributes) {
                foreach (var na in attr.NamedArguments) {
                    var x = na.MemberName;
                    var y = na.TypedValue.Value;
                }
            }
            JObject o = (JObject)t;
        }


    }
}
