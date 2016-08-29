using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Slimpay.Net.Gateway.Core.Enums
{
  public enum FrequencyType
  {
    [EnumMember(Value = "daily")]
    Daily,

    [EnumMember(Value = "weekly")]
    Weekly,

    [EnumMember(Value = "monthly")]
    Monthly,

    [EnumMember(Value = "bimonthly")]
    BiMonthly,

    [EnumMember(Value = "trimonthly")]
    TriMonthly,

    [EnumMember(Value = "semiyearly")]
    SemiYearly,

    [EnumMember(Value = "yearly")]
    Yearly
  }
}
