using System.Collections.Generic;
using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Mandates;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// A sign mandate order item representation. A sign mandate order item is the item to use in order to create and sign a mandate.
  /// </summary>
  public class MandateItem : OrderItem
  {
    [JsonProperty("autoGenReference")]
    public bool? AutoGenReference { get; set; }

    [JsonProperty("mandate")]
    public MandateRequest Mandate { get; set; }

    [JsonProperty("extraParams")]
    public Dictionary<string, object> ExtraParams { get; set; }

    public MandateItem() 
      : base(OperationItemType.SignMandate)
    {
    }

    public override string ToString()
    {
      return string.Format("MandateItem{type={0}, mandate={1}}", Type, Mandate);
    }
  }
}