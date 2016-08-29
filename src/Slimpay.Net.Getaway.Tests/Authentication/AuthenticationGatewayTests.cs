using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Auth;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Authentication
{
  public class AuthenticationGatewayTests
  {
    // Testing only AppToken here as demo user has no admin_scope.
    private AuthenticationGateway _authenticationGateway;

    [Fact]
    public void AppToken_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var appToken = gateway.AppToken();

      // Assert
      Assert.NotNull(appToken);
      Assert.Equal(appToken.Scope, "api");
      Assert.Equal(appToken.TokenType, "bearer");
      Assert.NotNull(appToken.AccessToken);
      Assert.True(appToken.ExpiresIn > 0);
    }

    private AuthenticationGateway GetGateway()
    {
      if (_authenticationGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
       );

        _authenticationGateway = slimpayGateway.AuthenticationGateway();
      }

      return _authenticationGateway;
    }
  }
}
