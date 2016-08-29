using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.App
{
  public class AppRequest : HalResource
  {
    [JsonProperty("notifyUrl")]
    public string NotifyUrl { get; set; }

    [JsonProperty("returnUrl")]
    public string ReturnUrl { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    public override string ToString()
    {
      return string.Format("AppRequest{notifyurl={0},returnurl={1},secret={2}}", NotifyUrl, ReturnUrl, Secret);
    }
  }
}