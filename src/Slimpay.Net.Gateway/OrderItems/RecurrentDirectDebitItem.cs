using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.DirectDebits;

namespace Slimpay.Net.Gateway.OrderItems
{
  public class RecurrentDirectDebitItem : OrderItem
  {
    [JsonProperty("recurrentDirectDebit")]
    public RecurrentDirectDebit RecurrentDirectDebit { get; set; }

    public RecurrentDirectDebitItem()
      : base(OperationItemType.RecurrentDirectDebit)
    {
    }

    public override string ToString()
    {
      return string.Format("RecurrentDirectDebitItem{type={0}, recurrentDirectDebit={1}}",
        Type, RecurrentDirectDebit);
    }
  }
}