using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace BorderEast.ArangoDB.Client.Utils {
    internal class DynamicUtil {

        internal static string GetTypeName(Type t) {
            if (t.GetTypeInfo().GetCustomAttribute(typeof(JsonObjectAttribute)) is JsonObjectAttribute attr) {
                return attr.Id ?? t.Name;
            }
            return t.Name;
        }

        internal static Dictionary<string, object> DynamicToDict(object dynamicObject) {
            var attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var property in dynamicObject.GetType().GetProperties(attr)) {
                if (property.CanRead) {
                    dict.Add(property.Name, property.GetValue(dynamicObject, null));
                }
            }
            return dict;
        }

    }
}
