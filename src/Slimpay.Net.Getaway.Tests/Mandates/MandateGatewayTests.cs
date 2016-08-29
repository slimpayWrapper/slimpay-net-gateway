using System;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Addresses;
using Slimpay.Net.Gateway.BankAccounts;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.Subscribers;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Mandates
{
  public class MandateGatewayTests
  {
    private MandateGateway _mandateGateway;

    [Fact]
    public void CreateMandate_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var mandate = gateway.Create(
        new CreateMandateRequest
        {
          DateSigned = DateTime.Now.AddDays(-6),
          CreateSequenceType = SequenceType.FRST,
          Subscriber = new Subscriber
          {
            Reference = "subscriber01"
          },
          Signatory = new MandateItemSignatory
          {
            HonoricPrefix = HonorificPrefix.Mr,
            FamilyName = "Doe",
            GivenName = "John",
            Telephone = "+33612345678",
            Email = "change.me@slimpay.com",
            BillingAddress = new Address
            {
              Street1 = "27 rue des fleurs",
              Street2 = "Bat 2",
              PostalCode = "75008",
              City = "Paris",
              Country = "FR"
            },
            BankAccount = new BankAccount
            {
              Bic = "DEUTFRPP",
              Iban = "FR7616348000011523645985206"
            }
          }
        }).Body;

      // Assert
      Assert.Equal(7, mandate.Links.Count);
      Assert.NotNull(mandate.Id);
      Assert.NotNull(mandate.Reference);
      Assert.NotNull(mandate.Rum);
      Assert.Equal(Standard.SEPA, mandate.Standard);
      Assert.Equal(MandateState.Active, mandate.State);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, mandate.PaymentScheme);
      Assert.NotEqual(DateTime.MinValue, mandate.DateSigned);
      Assert.NotNull(mandate.DateCreated);
    }

    [Fact]
    public void Find_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var gateway = GetGateway();

      // Act
      var mandate = gateway.Find("SLMP002958317").Body;

      // Assert
      Assert.NotEmpty(mandate.Links);
      Assert.NotNull(mandate.Id);
      Assert.Equal("SLMP002958317", mandate.Reference);
      Assert.Equal("SLMP002958317", mandate.Rum);
      Assert.Equal(MandateState.Active, mandate.State);
      Assert.Equal(Standard.SEPA, mandate.Standard);
      Assert.NotNull(mandate.DateCreated);
      Assert.NotNull(mandate.DateSigned);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, mandate.PaymentScheme);
    }

    private MandateGateway GetGateway()
    {
      if (_mandateGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
          );

        _mandateGateway = slimpayGateway.MandateGateway();
      }

      return _mandateGateway;
    }
  }
}