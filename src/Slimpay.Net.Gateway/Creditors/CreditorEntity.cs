using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Creditors
{
  /// <summary>
  /// A creditor entity representation. A creditor entity, also known as branch, is a sub-unit of a merchant’s company.
  /// </summary>
  public class CreditorEntity : HalResource
  {
    [JsonProperty("reference")]
    public string Reference { get; set; }

    public override string ToString()
    {
      return string.Format("CreditorEntity{reference='{0}'}", Reference);
    }
  }
}