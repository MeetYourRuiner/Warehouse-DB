using DBClient.Models.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DBClient
{
    public class JsonContractResolver : DefaultContractResolver
    {

        public JsonContractResolver()
        { }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            properties = properties
                .Where(p =>
                    {
                        var prop = type.GetProperty(p.PropertyName);
                        bool isntRelated = prop.GetCustomAttribute<RelatedEntityAttribute>(false) == null;
                        bool isntDisplay = prop.Name != "Display";
                        return isntDisplay && isntRelated;
                    })
                .ToList();

            return properties;
        }
    }
}
