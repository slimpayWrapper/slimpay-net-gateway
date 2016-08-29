using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Auth
{
  /// <summary>
  /// Gateway to slimpay authentication gateway.
  /// </summary>
  public class AuthenticationGateway : IAuthenticationGateway
  {
    private IHttpClient _http;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthenticationGateway(IHttpClient http)
    {
      _http = http;
    }

    /// <summary>
    /// Get a token for the application.
    /// </summary>
    public virtual Token AppToken()
    {
      _http.Authenticate();
      return _http.Token;
    }

    /// <summary>
    /// Get an administration token to slimpay api.
    /// @return
    /// </summary>
    public virtual Token AdminToken()
    {
      _http.AuthenticateAsAdmin();
      return _http.Token;
    }
  }
}