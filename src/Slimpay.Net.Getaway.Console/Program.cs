using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Addresses;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Enums;
using Slimpay.Net.Gateway.DirectDebits;
using Slimpay.Net.Gateway.Documents;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.OrderItems;
using Slimpay.Net.Gateway.Orders;
using Slimpay.Net.Gateway.Subscribers;
using System;
using System.Collections.Generic;

namespace Slimpay.Net.Getaway.Console
{
  public class SlimpayNetGateway
  {
    public static void Main(string[] args)
    {
      // Step 1: instantiate the gateway with your credentials
      SlimpayGateway slimpayGateway = new SlimpayGateway(
        SlimpayEnvironment.SANDBOX,
        "andrei.karzhou@1datagroup.com",
        "a102030",
        "democreditor01",
        "demosecret01",
        "hbp53fd0lygb"
      );

  //    SlimpayGateway slimpayGateway2 = new SlimpayGateway(
  //SlimpayEnvironment.SANDBOX,
  //"admin_user@gmail.com",
  //"usersecret",
  //"democreditor01",
  //"demosecret01",
  //"democreditor"
//);

      //var a = slimpayGateway.AppGateway().All();
      //var z = a;
      var b = slimpayGateway.AppGateway().Find("hbp53fd0lygb");
      var zz = b;
      //var directDebitGateway = slimpayGateway.DirectDebitGateway();
      //var directDebit = directDebitGateway.CreateStandalone(
      //  new CreateDirectDebitRequest()
      //  {
      //    Amount = 100,
      //    Label = "The Label",
      //    PaymentReference = "Payment 123",
      //    Subscriber = new Subscriber()
      //    {
      //      Reference = "subscriber01"
      //    }
      //  });

      //var directDebitUpd = directDebitGateway.UpdateStandalone(
      //  new UpdateDirectDebitRequest()
      //  {
      //    Id = directDebit.Id,
      //    Amount = 200,
      //    Label = "Updated",
      //    PaymentReference = "Payment 321",
      //    ExecutionDate = DateTime.Now.AddDays(10)
      //  });

      //var orderGateway = slimpayGateway.OrderGateway();
      //var order = orderGateway.Find("1");
      //order = orderGateway.Create(
      //  new OrderRequest()
      //  {
      //    Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
      //    Items = new List<OrderItem>()
      //    {
      //      new MandateItem()
      //      {
      //        Mandate = new MandateRequest()
      //        {
      //          Signatory = new MandateItemSignatory()
      //          {
      //            HonoricPrefix = HonorificPrefix.Mr,
      //            FamilyName = "Doe",
      //            GivenName = "John",
      //            Telephone = "+33612345678",
      //            Email = "change.me@slimpay.com",
      //            BillingAddress = new Address()
      //            {
      //              Street1 = "27 rue des fleurs",
      //              Street2 = "Bat 2",
      //              PostalCode = "75008",
      //              City = "Paris",
      //              Country = "FR"
      //            }
      //          }
      //        }
      //      },
      //      new SubscriberLoginItem()
      //      {
      //        Mode = new SubscriberLoginMode()
      //        {
      //          Type = SubscriberLoginModeType.ManageMandates,
      //          CardOperation = OperationType.Authorization
      //        }
      //      }
      //    }
      //  });

      //var document = slimpayGateway.DocumentGateway().Create(
      //  new DocumentRequest()
      //  {
      //    Timestamped = true,
      //    BinaryContent = new BinaryContentRequest()
      //    {
      //      Content = "JVBERi0xLjQKJeLjz9MKMiAwIG9iago8PC9MZW5ndGggOTQvRmlsdGVyL0ZsYXRlRGVjb2RlPj5zdHJlYW0KeJwr5HIK4TI2U7AwMFMISeEyUNA1tAAx9N0MFQyNFELSuDQ8UnNy8hXC84tyUhQVwlNTFNxSkxSAqgyNrAyMrYwsFZxdQxSMDAxNNUOygAYYgLS7hnAFcgEA5PgVTwplbmRzdHJlYW0KZW5kb2JqCjQgMCBvYmoKPDwvUGFyZW50IDMgMCBSL0NvbnRlbnRzIDIgMCBSL1R5cGUvUGFnZS9SZXNvdXJjZXM8PC9Qcm9jU2V0IFsvUERGIC9UZXh0IC9JbWFnZUIgL0ltYWdlQyAvSW1hZ2VJXS9Gb250PDwvRjEgMSAwIFI+Pj4+L01lZGlhQm94WzAgMCA1OTUgODQyXT4+CmVuZG9iagoxIDAgb2JqCjw8L0Jhc2VGb250L0hlbHZldGljYS9UeXBlL0ZvbnQvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nL1N1YnR5cGUvVHlwZTE+PgplbmRvYmoKMyAwIG9iago8PC9UeXBlL1BhZ2VzL0NvdW50IDEvS2lkc1s0IDAgUl0+PgplbmRvYmoKNSAwIG9iago8PC9UeXBlL0NhdGFsb2cvUGFnZXMgMyAwIFI+PgplbmRvYmoKNiAwIG9iago8PC9Qcm9kdWNlcihpVGV4dK4gNS40LjEgqTIwMDAtMjAxMiAxVDNYVCBCVkJBIFwoQUdQTC12ZXJzaW9uXCkpL01vZERhdGUoRDoyMDE1MDIxODEyMDMyOSswMScwMCcpL0NyZWF0aW9uRGF0ZShEOjIwMTUwMjE4MTIwMzI5KzAxJzAwJyk+PgplbmRvYmoKeHJlZgowIDcKMDAwMDAwMDAwMCA2NTUzNSBmIAowMDAwMDAwMzMyIDAwMDAwIG4gCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwMDQyMCAwMDAwMCBuIAowMDAwMDAwMTc1IDAwMDAwIG4gCjAwMDAwMDA0NzEgMDAwMDAgbiAKMDAwMDAwMDUxNiAwMDAwMCBuIAp0cmFpbGVyCjw8L1Jvb3QgNSAwIFIvSUQgWzwzZWRhMDI0N2RmYjE4NGZlNDY2ODZkZTEyYWU5OTQyZT48NmQyODVkNzBlYTg0ZGZhZjhhNDAxNzcxOGVlMjM0ZTU+XS9JbmZvIDYgMCBSL1NpemUgNz4+CiVpVGV4dC01LjQuMQpzdGFydHhyZWYKNjY5CiUlRU9GCg=="
      //    }
      //  });

      //var creditors = slimpayGateway.CreditorGateway().Find();
      // Step 2: create an order with a card debit.
      //OrderRequest orderRequest = new OrderRequest()
      //  .subscriberRequest()
      //    .reference("subscriber01")
      //    .done()
      //  .mandateRequest()
      //    .signatoryRequest()
      //      .honoricPrefix(SignatoryRequest.HonorificPrefix.Mr)
      //      .familyName("Doe")
      //      .givenName("John")
      //      .telephone("+33612345678")
      //      .email("john.doe@gmail.com")
      //      .billingAddressRequest()
      //        .street1("27 rue des fleurs")
      //        .street2("Bat 2")
      //        .postalCode("75008")
      //        .city("Paris")
      //        .iso2Country("FR")
      //        .done()
      //      .done()
      //    .done()
      //  .cardTransactionRequest()
      //    .amount(new BigDecimal(100))
      //    .operation(CardTransactionRequest.Operation.authorizationDebit)
      //    .done()
      //  .start();

      //var apps = slimpayGateway.AppGateway();
      //var b = apps.All();

    }
  }
}
