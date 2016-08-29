using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Orders;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// Represent an item for a card transaction.
  /// </summary>
  public class CardTransactionItem : OrderItem
  {
    [JsonProperty("cardTransaction")]
    public CardTransactionRequest CardTransaction { get; set; }

    public CardTransactionItem()
      : base(OperationItemType.CardTransaction)
    {
    }

    public override string ToString()
    {
      return string.Format("CardTransactionItem{type={0}, cardTransaction={1}}", Type, CardTransaction);
    }
  }
}