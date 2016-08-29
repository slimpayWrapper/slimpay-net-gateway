using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.Orders
{
  /// <summary>
  /// Card transaction request.
  /// </summary>
  public class CardTransactionRequest
  {
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("operation")]
    public OperationType Operation { get; set; }

    public override string ToString()
    {
      return string.Format("CardTransactionRequest{amount={0}, operation='{1}'}",
        Amount, Operation);
    }
  }
}