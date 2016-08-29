using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.App
{
  public class App : HalResource
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("notifyUrl")]
    public string NotifyUrl { get; set; }

    [JsonProperty("returnUrl")]
    public string ReturnUrl { get; set; }

    public override string ToString()
    {
      return string.Format("App{{name='{0}', secret='{1}', reference='{2}', returnUrl='{3}'}}",
          Name, Secret, NotifyUrl, ReturnUrl);
    }
  }
}