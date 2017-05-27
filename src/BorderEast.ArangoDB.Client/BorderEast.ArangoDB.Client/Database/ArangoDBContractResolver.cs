using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ArangoDBContractResolver : DefaultContractResolver {
        public ArangoDBContractResolver() : base()
        {
            NamingStrategy = new CamelCaseNamingStrategy
            {
                ProcessDictionaryKeys = true,
                OverrideSpecifiedNames = false,
                ProcessExtensionDataNames = true
            };

            IgnoreSerializableAttribute = false;
            IgnoreSerializableInterface = false;
            
        }

        protected override IValueProvider CreateMemberValueProvider(MemberInfo member) {
            IValueProvider provider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property) {
                Type propType = ((PropertyInfo)member).PropertyType;
                TypeInfo propTypeInfo = propType.GetTypeInfo();
                if (propTypeInfo.IsGenericType &&
                    propType.GetGenericTypeDefinition() == typeof(List<>)) {
                    return new EmptyListValueProvider(provider, propType);
                }
            }

            return provider;
        }

        class EmptyListValueProvider : IValueProvider {
            private IValueProvider innerProvider;
            private object defaultValue;

            public EmptyListValueProvider(IValueProvider innerProvider, Type listType) {
                this.innerProvider = innerProvider;
                defaultValue = Activator.CreateInstance(listType);
            }

            public void SetValue(object target, object value) {
                innerProvider.SetValue(target, value ?? defaultValue);
            }

            public object GetValue(object target) {
                return innerProvider.GetValue(target) ?? defaultValue;
            }
        }
    }
}
