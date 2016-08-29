using Newtonsoft.Json;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Auth
{
  /// <summary>
  /// An Authentication token.
  /// </summary>
  public class Token : HalResource
  {
    [JsonProperty("Access_token")]
    public virtual string AccessToken { get; set; }

    [JsonProperty("Token_type")]
    public virtual string TokenType { get; set; }

    [JsonProperty("Expires_in")]
    public virtual long? ExpiresIn { get; set; }

    [JsonProperty("Scope")]
    public virtual string Scope { get; set; }
  }
}