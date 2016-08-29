using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Creditors
{
  /// <summary>
  /// Creditor request.
  /// </summary>
  public class CreditorRequest : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    [JsonProperty("entity")]
    public CreditorEntity Entity { get; set; }

    public override string ToString()
    {
      return string.Format("CreditorRequest{reference='{0}', entity={1}}", Reference, Entity);
    }
  }
}