using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slimpay.Net.Gateway.Core.Enums;

namespace Slimpay.Net.Gateway.Signatories
{
  /// <summary>
  /// A signatory representation. A signatory is a person who signs a document or a mandate. A signatory is primarily
  /// related to a mandate, a bank account and a billing address.
  /// </summary>
  public class Signatory : Person
  {
    [JsonProperty("companyName")]
    public string CompanyName { get; set; }

    [JsonProperty("organizationName")]
    public string OrganizationName { get; set; }

    public override string ToString()
    {
      return string.Format("Signatory{honoricPrefix='{0}', familyName='{1}', givenName='{2}', telephone='{3}', email='{4}', companyName='{5}', organizationName='{6}'}",
        HonoricPrefix, FamilyName, GivenName, Telephone, Email, CompanyName, OrganizationName);
    }
	}
}