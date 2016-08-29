using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Signatories
{
  /// <summary>
  /// A person representation. A person contains identification information.
  /// </summary>
  public class Person : HalResource
  {
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("honorificPrefix")]
    public HonorificPrefix HonoricPrefix { get; set; }

    [JsonProperty("familyName")]
    public string FamilyName { get; set; }

    [JsonProperty("givenName")]
    public string GivenName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("telephone")]
    public string Telephone { get; set; }

    public override string ToString()
    {
      return string.Format("Person{honoricPrefix='{0}', familyName='{1}', givenName='{2}', telephone='{3}', email='{4}'}",
        HonoricPrefix, FamilyName, GivenName, Telephone, Email);
    }
  }
}
