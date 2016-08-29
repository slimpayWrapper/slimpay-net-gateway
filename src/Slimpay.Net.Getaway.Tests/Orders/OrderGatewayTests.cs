using System;
using System.Collections.Generic;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Addresses;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.DirectDebits;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.OrderItems;
using Slimpay.Net.Gateway.Orders;
using Slimpay.Net.Gateway.Subscribers;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Order
{
  public class OrderGatewayTests
  {
    private OrderGateway _orderGateway;

    [Fact]
    public void Find_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();

      // Act
      var order = orderGateway.Find("1").Body;

      // Assert
      Assert.Equal(5, order.Links.Count);
      Assert.NotNull(order.Reference);
      Assert.NotNull(order.State);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.True(order.Started);
    }

    [Fact]
    public void CreateSubscriberLoginManageMandatesItem_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new SubscriberLoginItem()
            {
              Mode = new SubscriberLoginMode()
              {
                Type = SubscriberLoginModeType.ManageMandates
              }
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateSubscriberLoginRecoveryDebtItem_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new SubscriberLoginItem()
            {
              Mode = new SubscriberLoginMode()
              {
                Type = SubscriberLoginModeType.RecoverDebt,
                CardOperation = OperationType.Authorization
              }
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateMandateSignatureItem_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();
      var extraParams = new Dictionary<string, object>();
      extraParams.Add("firstName", "Wolf");

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new MandateItem()
            {
              AutoGenReference = true,
              Mandate = new MandateRequest()
              {
                Signatory = new MandateItemSignatory()
                {
                  HonoricPrefix = HonorificPrefix.Mr,
                  FamilyName = "Doe",
                  GivenName = "John",
                  Telephone = "+33612345678",
                  Email = "change.me@slimpay.com",
                  BillingAddress = new Address()
                  {
                    Street1 = "27 rue des fleurs",
                    Street2 = "Bat 2",
                    PostalCode = "75008",
                    City = "Paris",
                    Country = "FR"
                  }
                }
              },
              ExtraParams = extraParams
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateMandateSignatureItemWithFirstDirectDebit_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();
      var extraParams = new Dictionary<string, object>();
      extraParams.Add("firstName", "Wolf");

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new MandateItem()
            {
              AutoGenReference = true,
              Mandate = new MandateRequest()
              {
                Signatory = new MandateItemSignatory()
                {
                  HonoricPrefix = HonorificPrefix.Mr,
                  FamilyName = "Doe",
                  GivenName = "John",
                  Telephone = "+33612345678",
                  Email = "change.me@slimpay.com",
                  BillingAddress = new Address()
                  {
                    Street1 = "27 rue des fleurs",
                    Street2 = "Bat 2",
                    PostalCode = "75008",
                    City = "Paris",
                    Country = "FR"
                  }
                }
              },
              ExtraParams = extraParams
            },
            new DirectDebitItem()
            {
              DirectDebit = new DirectDebit()
              {
                Amount = 100,
                Label = "The label",
                PaymentReference = "Payment 123"
              }
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateMandateSignatureItemWithRecurrentDirectDebit_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();
      var extraParams = new Dictionary<string, object>();
      extraParams.Add("firstName", "Wolf");

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new MandateItem()
            {
              AutoGenReference = true,
              Mandate = new MandateRequest()
              {
                Signatory = new MandateItemSignatory()
                {
                  HonoricPrefix = HonorificPrefix.Mr,
                  FamilyName = "Doe",
                  GivenName = "John",
                  Telephone = "+33612345678",
                  Email = "change.me@slimpay.com",
                  BillingAddress = new Address()
                  {
                    Street1 = "27 rue des fleurs",
                    Street2 = "Bat 2",
                    PostalCode = "75008",
                    City = "Paris",
                    Country = "FR"
                  }
                }
              },
              ExtraParams = extraParams
            },
            new RecurrentDirectDebitItem()
            {
              RecurrentDirectDebit = new RecurrentDirectDebit()
              {
                Amount = 192,
                Frequency = FrequencyType.Monthly,
                Label = "This is my Recurrent Direct Debit",
                Activated = true,
                MaxSddNumber = 5,
                DateFrom = DateTime.Now.AddMonths(1)
              }
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateMandateSignatureItemWithDirectDebitAndRecurrentDirectDebit_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();
      var extraParams = new Dictionary<string, object>();
      extraParams.Add("firstName", "Wolf");

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new MandateItem()
            {
              AutoGenReference = true,
              Mandate = new MandateRequest()
              {
                Signatory = new MandateItemSignatory()
                {
                  HonoricPrefix = HonorificPrefix.Mr,
                  FamilyName = "Doe",
                  GivenName = "John",
                  Telephone = "+33612345678",
                  Email = "change.me@slimpay.com",
                  BillingAddress = new Address()
                  {
                    Street1 = "27 rue des fleurs",
                    Street2 = "Bat 2",
                    PostalCode = "75008",
                    City = "Paris",
                    Country = "FR"
                  }
                }
              },
              ExtraParams = extraParams
            },
            new DirectDebitItem()
            {
              DirectDebit = new DirectDebit()
              {
                Amount = 100,
                Label = "The label",
                PaymentReference = "Payment 123"
              }
            },
            new RecurrentDirectDebitItem()
            {
              RecurrentDirectDebit = new RecurrentDirectDebit()
              {
                Amount = 192,
                Frequency = FrequencyType.Monthly,
                Label = "This is my Recurrent Direct Debit",
                Activated = true,
                MaxSddNumber = 5,
                DateFrom = DateTime.Now.AddMonths(1)
              }
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    [Fact]
    public void CreateMandateSignatureItemWithoutRUM_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      var orderGateway = GetGateway();
      var extraParams = new Dictionary<string, object>();
      extraParams.Add("firstName", "Wolf");

      // Act
      var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List<OrderItem>()
          {
            new MandateItem()
            {
              AutoGenReference = false,
              Mandate = new MandateRequest()
              {
                Signatory = new MandateItemSignatory()
                {
                  HonoricPrefix = HonorificPrefix.Mr,
                  FamilyName = "Doe",
                  GivenName = "John",
                  Telephone = "+33612345678",
                  Email = "change.me@slimpay.com",
                  BillingAddress = new Address()
                  {
                    Street1 = "27 rue des fleurs",
                    Street2 = "Bat 2",
                    PostalCode = "75008",
                    City = "Paris",
                    Country = "FR"
                  }
                }
              },
              ExtraParams = extraParams
            }
          },
          Started = true
        }).Body;

      // Assert
      Assert.NotEmpty(order.Links);
      Assert.NotNull(order.Reference);
      Assert.Equal("open.running", order.State);
      Assert.True(order.Started);
      Assert.NotEqual(DateTime.MinValue, order.DateCreated);
      Assert.Equal(PaymentScheme.SEPA_DIRECT_DEBIT_CORE, order.PaymentScheme);
      Assert.NotNull(order.GetUserApprovalLink());
      Assert.NotNull(order.GetExtendedUserApprovalLink());
    }

    private OrderGateway GetGateway()
    {
      if (_orderGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
          "admin_user@gmail.com",
          "usersecret",
          "democreditor01",
          "demosecret01",
          "democreditor"
       );

        _orderGateway = slimpayGateway.OrderGateway();
      }

      return _orderGateway;
    }
  }
}
