using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum PaymentScheme
  {
    [EnumMember(Value = "SEPA.DIRECT_DEBIT.CORE")]
    SEPA_DIRECT_DEBIT_CORE,

    [EnumMember(Value = "SEPA.DIRECT_DEBIT.B2B")]
    SEPA_DIRECT_DEBIT_B2B,

    [EnumMember(Value = "BACS.DIRECT_DEBIT")]
    BACS_DIRECT_DEBIT
  }
}
