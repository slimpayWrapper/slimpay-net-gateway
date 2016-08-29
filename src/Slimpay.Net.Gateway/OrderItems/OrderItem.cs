using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// Order item request.
  /// </summary>
  public abstract class OrderItem
  {
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public OperationItemType Type { get; private set; }

    protected OrderItem()
    {
    }

    protected OrderItem(OperationItemType type)
    {
      Type = type;
    }
  }
}