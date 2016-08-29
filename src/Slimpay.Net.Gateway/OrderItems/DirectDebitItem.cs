using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.DirectDebits;
using Slimpay.Net.Gateway.Orders;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// A direct debit order item representation. A direct debit order item is the item to use in order to create a direct debit.
  /// </summary>
  public class DirectDebitItem : OrderItem
  {
    [JsonProperty("directDebit")]
    public DirectDebit DirectDebit { get; set; }

    public DirectDebitItem()
      : base(OperationItemType.DirectDebit)
    {
    }

    public override string ToString()
    {
      return string.Format("DirectDebitItem{type={0}, directDebit={1}}", Type, DirectDebit);
    }
  }
}