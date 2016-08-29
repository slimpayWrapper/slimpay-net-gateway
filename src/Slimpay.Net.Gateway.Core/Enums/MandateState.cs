using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum MandateState
  {
    [EnumMember(Value = "created")]
    Created,

    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "revoked")]
    Revoked,

    [EnumMember(Value = "expired")]
    Expired
  }
}
