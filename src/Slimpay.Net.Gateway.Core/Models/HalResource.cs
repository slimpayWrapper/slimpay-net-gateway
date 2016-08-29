using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Core.Models
{
  public class HalResource : IHalResource
  {
    public HalResource()
    {
      Links = new HalLinkCollection();
      IsNew = true;
    }

    [JsonIgnore]
    public HalLinkCollection Links { get; set; }

    [JsonIgnore]
    public bool IsNew { get; set; }
  }
}