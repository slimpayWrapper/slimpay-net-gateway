using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Json.Converters;

namespace Slimpay.Net.Gateway.Core.Json.Serializers
{
  public class HalJsonSerializer : IHalJsonSerializer
  {
    public T Deserialize<T>(string jsonContent) where T : new()
    {
      return JsonConvert.DeserializeObject<T>(jsonContent, new JsonConverter[] { new HalResourceConverter() });
    }
  }
}
