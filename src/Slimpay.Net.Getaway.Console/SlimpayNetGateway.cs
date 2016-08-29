using System;
using System.Collections.Generic;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Addresses;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.OrderItems;
using Slimpay.Net.Gateway.Orders;

namespace Slimpay.Net.Getaway.Console
{
  public class SlimpayNetGateway
  {
    public static void Main(string[] args)
    {
      // Step 1: instantiate the gateway with your credentials
      SlimpayGateway slimpayGateway = new SlimpayGateway(
        SlimpayEnvironment.SANDBOX,
        "admin_user@gmail.com",
        "usersecret",
        "democreditor01",
        "demosecret01",
        "democreditor"
      );

      var orderGateway = slimpayGateway.OrderGateway();

      // Step 2: create an order with a card debit.
      var orderRequest = new OrderRequest()
      {
        Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
        Items = new List<OrderItem>()
          {
            new MandateItem()
            {
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
              }
            },
            new CardTransactionItem
            {
              CardTransaction =  new CardTransactionRequest
              {
                Amount = 100,
                Operation = OperationType.AuthorizationDebit
              }
            }
          }
      };

      // Step 3: send the request to Slimpay
      var orderResponse = orderGateway.Create(orderRequest);

      // Step 4: check the response to the request.
      if (orderResponse.Success)
      {
        System.Console.WriteLine(String.Format("Order created successfully. Reference of the order is {0}.", orderResponse.Body.Reference));
      }
      else
      {
        System.Console.WriteLine(String.Format("Cannot create the order. Problem: {0}", orderResponse.Error.Message));
      }
    }
  }
}
