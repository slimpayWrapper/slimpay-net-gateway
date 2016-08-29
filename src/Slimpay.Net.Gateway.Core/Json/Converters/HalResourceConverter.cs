using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Slimpay.Net.Gateway.Core.Attributes;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Json.Converters
{
  class HalResourceConverter : JsonConverter
  {
    public HalResourceConverter(Type type = null)
    {
      ObjectType = type;
    }

    protected Type ObjectType { get; set; }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      var obj = JToken.ReadFrom(reader);
      var ret = JsonConvert.DeserializeObject(obj.ToString(), ObjectType ?? objectType, new JsonConverter[] { });
      if (obj["_embedded"] != null && obj["_embedded"].HasValues)
      {
        var enumerator = ((JObject)obj["_embedded"]).GetEnumerator();
        while (enumerator.MoveNext())
        {
          var rel = enumerator.Current.Key;
          foreach (var property in objectType.GetProperties())
          {
            var attribute = property.GetCustomAttributes(true).FirstOrDefault(attr => attr is HalEmbeddedAttribute &&
                                                                                      ((HalEmbeddedAttribute)attr).Rel == rel);
            if (attribute != null)
            {
              var type = (attribute as HalEmbeddedAttribute).Type ?? property.PropertyType;
              property.SetValue(ret,
                                JsonConvert.DeserializeObject(enumerator.Current.Value.ToString(), type,
                                                              new JsonConverter[] { new HalResourceConverter((attribute as HalEmbeddedAttribute).CollectionMemberType) }), null);
            }
          }
        }
      }
      if (obj["_links"] != null && obj["_links"].HasValues && typeof(IHalResource).IsAssignableFrom(objectType))
      {
        ((HalResource)ret).Links = JsonConvert.DeserializeObject<HalLinkCollection>(obj["_links"].ToString(),
                                                                                     new JsonConverter[] { new LinkCollectionConverter() });
      }
      if (ret is IHalResource)
        ((IHalResource)ret).IsNew = false;
      return ret;
    }

    public override bool CanConvert(Type objectType)
    {
      return typeof(IHalResource).IsAssignableFrom(objectType);
    }
  }
}
