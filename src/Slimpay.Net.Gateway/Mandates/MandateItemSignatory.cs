using Newtonsoft.Json;
using Slimpay.Net.Gateway.Addresses;
using Slimpay.Net.Gateway.BankAccounts;
using Slimpay.Net.Gateway.Signatories;

namespace Slimpay.Net.Gateway.Mandates
{
  /// <summary>
  /// Signatory representation.
  /// </summary>
  public class MandateItemSignatory : Signatory
  {
    [JsonProperty("billingAddress")]
    public Address BillingAddress { get; set; }

    [JsonProperty("bankAccount")]
    public BankAccount BankAccount { get; set; }

    public override string ToString()
    {
      return string.Format("MandateItemSignatory{honoricPrefix='{0}', familyName='{1}', givenName='{2}', telephone='{3}', email='{4}', companyName='{5}', organizationName='{6}', billingAddress={7}, bankAccount={8}}",
        HonoricPrefix, FamilyName, GivenName, Telephone, Email, CompanyName, OrganizationName, BillingAddress, BankAccount);
    }
  }
}