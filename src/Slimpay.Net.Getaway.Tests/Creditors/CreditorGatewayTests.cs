using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Creditors;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Creditors
{
  public class CreditorGatewayTests
  {
    private CreditorGateway _creditorGateway;

    [Fact]
    public void Find_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var creditor = gateway.Find().Body;

      // Assert
      Assert.Equal(3, creditor.Links.Count);
      Assert.Equal("democreditor", creditor.Reference);
    }

    private CreditorGateway GetGateway()
    {
      if (_creditorGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
       );

        _creditorGateway = slimpayGateway.CreditorGateway();
      }

      return _creditorGateway;
    }
  }
}
