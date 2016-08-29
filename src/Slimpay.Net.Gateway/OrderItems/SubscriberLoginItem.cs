using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Subscribers;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// Represent a subscriber login request item.
  /// </summary>
  public class SubscriberLoginItem : OrderItem
  {
    [JsonProperty("mode")]
    public SubscriberLoginMode Mode { get; set; }

    public SubscriberLoginItem()
      : base(OperationItemType.SubscriberLogin)
    {
    }

    public override string ToString()
    {
      return string.Format("SubscriberLoginItem{type={0}, mode={1}}",
        Type, Mode);
    }
  }
}