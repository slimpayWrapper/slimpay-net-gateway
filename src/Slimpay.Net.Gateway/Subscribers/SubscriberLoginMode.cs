using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.Subscribers
{
  public class SubscriberLoginMode
  {
    private OperationType _cardOperation;

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("type")]
    public SubscriberLoginModeType Type { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("cardOperation")]
    public OperationType CardOperation
    {
      get
      {
        return _cardOperation;
      }
      set
      {
        if (value == OperationType.Authorization || value == OperationType.AuthorizationDebit)
        {
          _cardOperation = value;
        }
        else
        {
          throw new NotSupportedException(string.Format("SubscriberLoginMode - CardOperation {0} is not supported", value));
        }
      }
    }

    // Is used by conditional serialization
    public bool ShouldSerializeCardOperation()
    {
      return Type == SubscriberLoginModeType.RecoverDebt;
    }

    public override string ToString()
    {
      return string.Format("SubscriberLoginMode{type={0}, cardOperation={1}}",
        Type, CardOperation);
    }
  }
}