using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Core.Models
{
  public class HalLink
  {
    public HalLink() { }

    public HalLink(string href)
    {
      this.Href = href;
    }

    public string Rel { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("templated")]
    public bool IsTemplated { get; set; }
  }
}