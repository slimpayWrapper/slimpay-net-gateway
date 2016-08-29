using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.BankAccounts
{
  /// <summary>
  /// A bank account representation.
  /// </summary>
  public class BankAccount
  {
    [JsonProperty("bic")]
    public string Bic { get; set; }

    [JsonProperty("iban")]
    public string Iban { get; set; }

    public override string ToString()
    {
      return string.Format("BankAccount{bic='{0}', iban='{1}'}",
        Bic, Iban);
    }
  }
}