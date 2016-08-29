using System.Runtime.Serialization;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum ExecutionStatus
  {
    [EnumMember(Value = "processing")]
    Processing,

    [EnumMember(Value = "rejected")]
    Rejected,

    [EnumMember(Value = "processed")]
    Processed,

    [EnumMember(Value = "notprocessed")]
    NotProcessed,

    [EnumMember(Value = "transformed")]
    Transformed,

    [EnumMember(Value = "contested")]
    Contested,

    [EnumMember(Value = "toreplay")]
    ToReplay,

    [EnumMember(Value = "togenerate")]
    ToGenerate,

    [EnumMember(Value = "toprocess")]
    ToProcess
  }
}