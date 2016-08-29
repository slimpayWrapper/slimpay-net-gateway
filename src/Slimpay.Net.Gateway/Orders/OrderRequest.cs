using System.Collections.Generic;
using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;
using Slimpay.Net.Gateway.OrderItems;

namespace Slimpay.Net.Gateway.Orders
{
  /// <summary>
  /// An order request.
  /// </summary>
  public class OrderRequest : HalResource
  {
    [JsonProperty("creditor")]
    public CreditorRequest Creditor { get; set; }

    [JsonProperty("subscriber")]
    public SubscriberRequest Subscriber { get; set; }

    [JsonProperty("items")]
    public IList<OrderItem> Items { get; set; }

    [JsonProperty("started")]
    public bool Started { get; set; }

    public OrderRequest()
    {
      Items = new List<OrderItem>();
    }

    public override string ToString()
    {
      return string.Format("OrderRequest{creditor={0}, subscriber={1}, items=[{2}], started={3}}",
        Creditor, Subscriber, string.Join(", ", Items), Started);
    }
  }
}