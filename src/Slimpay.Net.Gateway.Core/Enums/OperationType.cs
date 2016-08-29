using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum OperationType
  {
    [EnumMember(Value = "authorization")]
    Authorization,

    [EnumMember(Value = "debit")]
    Debit,

    [EnumMember(Value = "authorizationDebit")]
    AuthorizationDebit,

    [EnumMember(Value = "credit")]
    Credit,

    [EnumMember(Value = "refund")]
    Refund,

    [EnumMember(Value = "cancel")]
    Cancel,

    [EnumMember(Value = "aliasAuthorization")]
    AliasAuthorization,

    [EnumMember(Value = "aliasDebit")]
    AliasDebit,

    [EnumMember(Value = "aliasCredit")]
    AliasCredit,

    [EnumMember(Value = "aliasCancel")]
    AliasCancel,

    [EnumMember(Value = "newAlias")]
    NewAlias,

    [EnumMember(Value = "aliasDelete")]
    AliasDelete
  }
}