using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum SubscriberLoginModeType
  {
    [EnumMember(Value = "manageMandates")]
    ManageMandates,

    [EnumMember(Value = "recoverDebt")]
    RecoverDebt
  }
}
