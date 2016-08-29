using System;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.CreditTransfers;
using Slimpay.Net.Gateway.Subscribers;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.CreditTransfers
{
  public class CreditTransfersGatewayTests
  {
    private CreditTransferGateway _creditorTransferGateway;

    [Fact]
    public void CreateBySubscriber_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Assert
      var gateway = GetGateway();

      // Act
      var creditTransfer = gateway.Create(
        new CreditTransferRequest()
        {
          Amount = 1,
          Label = "The Label",
          PaymentReference = "Payment 123",
          ExecutionDate = DateTime.Now.AddDays(7),
          Subscriber = new Subscriber()
          {
            Reference = "subscriber01"
          },
          Currency = CurrencyType.EUR
        }).Body;

      // Arrange
      Assert.Equal(5, creditTransfer.Links.Count);
      Assert.NotNull(creditTransfer.Id);
      Assert.Equal(1, creditTransfer.Amount);
      Assert.Equal("Payment 123", creditTransfer.PaymentReference);
      Assert.Equal("The Label", creditTransfer.Label);
      Assert.Equal(ExecutionStatus.ToProcess, creditTransfer.ExecutionStatus);
      Assert.Equal(CurrencyType.EUR, creditTransfer.Currency);
      Assert.NotEqual(DateTime.MinValue, creditTransfer.ExecutionDate);
      Assert.NotNull(creditTransfer.DateCreated);
    }

    private CreditTransferGateway GetGateway()
    {
      if (_creditorTransferGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
          );

        _creditorTransferGateway = slimpayGateway.CreditTransferGateway();
      }

      return _creditorTransferGateway;
    }
  }
}
