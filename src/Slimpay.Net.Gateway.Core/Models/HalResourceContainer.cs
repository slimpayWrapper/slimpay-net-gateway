using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Core.Models
{
  public class HalResourceContainer : HalResource
  {
    [JsonProperty("page")]
    public HalPaginationInfo PaginationInfo { get; set; }
  }
}
