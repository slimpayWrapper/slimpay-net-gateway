using System;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.DirectDebits;
using Slimpay.Net.Gateway.Subscribers;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.DirectDebits
{
  public class DirectDebitGatewayTests
  {
    private DirectDebitGateway _directDebitGateway;

    [Fact]
    public void CreateStandalone_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var directDebit = gateway.CreateStandalone(
        new CreateDirectDebitRequest()
        {
          Amount = 100,
          Label = "The Label",
          PaymentReference = "Payment 123",
          ExecutionDate = DateTime.Now.AddDays(7),
          Subscriber = new Subscriber()
          {
            Reference = "subscriber01"
          }
        }).Body;

      // Assert
      Assert.Equal(6, directDebit.Links.Count);
      Assert.NotNull(directDebit.Id);
      Assert.Equal(100, directDebit.Amount);
      Assert.Equal("Payment 123", directDebit.PaymentReference);
      Assert.Equal("The Label", directDebit.Label);
      Assert.Equal(SequenceType.FRST, directDebit.SequenceType);
      Assert.Equal(ExecutionStatus.ToProcess, directDebit.ExecutionStatus);
      Assert.Equal(CurrencyType.EUR, directDebit.Currency);
      Assert.NotEqual(DateTime.MinValue, directDebit.ExecutionDate);
      Assert.NotNull(directDebit.DateCreated);
    }

    [Fact]
    public void CreateRecurrent_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var recurrentDirectDebit = gateway.CreateRecurrent(
        new CreateRecurrentDirectDebitRequest()
        {
          Amount = 100,
          Label = "Your merchant.com subscription",
          Reference = "RDD-01",
          Frequency = FrequencyType.Monthly,
          MaxSddNumber = 12,
          Activated = true,
          DateFrom = DateTime.Now.AddDays(3),
          Subscriber = new Subscriber()
          {
            Reference = "subscriber01"
          }
        }).Body;

      // Assert
      Assert.NotNull(recurrentDirectDebit.Id);
      Assert.Equal(100, recurrentDirectDebit.Amount);
      Assert.Equal("RDD-01", recurrentDirectDebit.Reference);
      Assert.Equal("Your merchant.com subscription", recurrentDirectDebit.Label);
      Assert.Equal(FrequencyType.Monthly, recurrentDirectDebit.Frequency);
      Assert.Equal(CurrencyType.EUR, recurrentDirectDebit.Currency);
      Assert.Equal(12, recurrentDirectDebit.MaxSddNumber);
      Assert.Equal(true, recurrentDirectDebit.Activated);
      Assert.NotNull(recurrentDirectDebit.DateCreated);
      Assert.NotNull(recurrentDirectDebit.DateFrom);
    }

    [Fact]
    public void UpdateStandalone_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var directDebit = gateway.CreateStandalone(
        new CreateDirectDebitRequest()
        {
          Amount = 100,
          Label = "The Label",
          PaymentReference = "Payment 123",
          ExecutionDate = DateTime.Now.AddDays(7),
          Subscriber = new Subscriber()
          {
            Reference = "subscriber01"
          }
        }).Body;

      var directDebitUpdated = gateway.UpdateStandalone(
        new UpdateDirectDebitRequest()
        {
          Id = directDebit.Id,
          Amount = 200,
          Label = "Your merchant.com subscription updated",
          PaymentReference = "REFERENCE",
          ExecutionDate = new DateTime(2017, 1, 1)
        }).Body;

      // Assert
      Assert.Equal(directDebit.Id, directDebitUpdated.Id);
      Assert.Equal(200, directDebitUpdated.Amount);
      Assert.Equal("REFERENCE", directDebitUpdated.PaymentReference);
      Assert.Equal("Your merchant.com subscription updated", directDebitUpdated.Label);
      Assert.Equal(new DateTime(2017, 1, 1), directDebitUpdated.ExecutionDate);
    }

    [Fact]
    public void UpdateRecurrent_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var recurrentDirectDebit = gateway.CreateRecurrent(
        new CreateRecurrentDirectDebitRequest()
        {
          Amount = 100,
          Label = "Your merchant.com subscription",
          Reference = "RDD-01",
          Frequency = FrequencyType.Monthly,
          MaxSddNumber = 12,
          Activated = true,
          DateFrom = DateTime.Now.AddDays(3),
          Subscriber = new Subscriber()
          {
            Reference = "subscriber01"
          }
        }).Body;

      var recurrentDirectDebitUpdated = gateway.UpdateRecurrent(
        new UpdateRecurrentDirectDebitRequest()
        {
          Id = recurrentDirectDebit.Id,
          Amount = 200,
          Label = "Your merchant.com subscription updated"
        }).Body;

      // Assert
      Assert.Equal(recurrentDirectDebit.Id, recurrentDirectDebitUpdated.Id);
      Assert.Equal(200, recurrentDirectDebitUpdated.Amount);
      Assert.Equal("Your merchant.com subscription updated", recurrentDirectDebitUpdated.Label);
    }

    private DirectDebitGateway GetGateway()
    {
      if (_directDebitGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
       );

        _directDebitGateway = slimpayGateway.DirectDebitGateway();
      }

      return _directDebitGateway;
    }
  }
}
