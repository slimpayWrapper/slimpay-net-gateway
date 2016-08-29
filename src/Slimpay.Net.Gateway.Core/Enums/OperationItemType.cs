using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum OperationItemType
  {
    [EnumMember(Value = "signMandate")]
    SignMandate,

    [EnumMember(Value = "directDebit")]
    DirectDebit,

    [EnumMember(Value = "cardTransaction")]
    CardTransaction,

    [EnumMember(Value = "subscriberLogin")]
    SubscriberLogin,

    [EnumMember(Value = "recurrentDirectDebit")]
    RecurrentDirectDebit
  }
}
