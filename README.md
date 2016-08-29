Wrapper API documentation
=========================

Slimpay API wrapper provides access to Slimpay API using C\# classes to
simplify interactions with the APIs without need to manage low-level
details, such as retrieving access token, composing request and
deserializing response objects.

### **The Slimpay Gateway**

Before any operation with the API, you need to create an instance of the
*SlimpayGateway*. It is an entry point to all other gateways.

The constructor of this class takes as parameters:

- The environment that configures the authentication and entry point urls to Slimpay REST interface.
- The credentials to the service.

```C#
SlimpayGateway slimpayGateway = new
SlimpayGateway(
        SlimpayEnvironment.SANDBOX,
        "admin_user@gmail.com",
        "usersecret",
        "democreditor01",
        "demosecret01",
        "democreditor"
      );
```

### 

### **The Authentication Gateway**

*AuthenticationGateway* should be used to retrieve access token which is
needed for every request to the API. Usually you do not need to use it
because all the other gateways already contain authentication logic
which is wrapped by *AuthenticationGateway*.

```C#
var authenticationGateway = slimpayGateway.AuthenticationGateway();
```
With *AuthenticationGateway* you can:

Get App token (scope api)
```C#
var appToken = authenticationGateway.AppToken();
```
Get App admin token (scope api\_admin)
```C#
var adminToken = authenticationGateway.AdminToken();
```
### **The App Gateway**

*AppGateway* should be used to work with application data. Please note
that you need scope\_admin to access these APIs.

**Get Apps**

In order to get list of apps *AppGateway.All* method should be used.
```C#
var appGateway = slimpayGateway.AppGateway();
var apps = appGateway.All();
```
**Find App by name**

In order to find app by name *AppGateway.Find* method should be used.
```C#
var appGateway = slimpayGateway.AppGateway();
var app = appGateway.Find("demo app");
```
**Update App**

In order to update an app *AppGateway.Patch* method should be used with the following parameters:
```C#
var appGateway = slimpayGateway.AppGateway();
var app = appGateway.Patch("demo app", new AppRequest{NotifyUrl = "some value"});
```
### 
**The Creditor Gateway**

*CreditorGateway* may be used for retrieving Creditor entity which contains basic links for retrieving orders and mandates.

#### **Get a Creditor**

In order to find a creditor by reference *CreditorGateway.Find* method should be used. Creditor reference will be used from *SlimpayGateway* settings in this request.
```C#
var creditorGateway= slimpayGateway.CreditorGateway();
var mandate = creditorGateway.Find();
```
See full feature descripition at
[*https://api-sandbox.slimpay.net/docs/alps/v1/\#get-creditors-safe*](https://api-sandbox.slimpay.net/docs/alps/v1/#get-creditors-safe)

### **The Order Gateway**

*OrderGateway* should be used to create orders on Slimpay. The gateway
allows to create different kinds of orders allowed by Slimpay.  

### ***Mandate Features***

#### **Mandate signature**

In order to sign a mandate *OrderGateway.Create* method should be used with the following parameters:
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```
See full feature descripition at
[*https://api-sandbox.slimpay.net/docs/\#mandate-signature*](https://api-sandbox.slimpay.net/docs/#mandate-signature)

#### 

#### **Mandate Signature With First Direct Debit**

In order to sign a mandate and process a first direct debit *OrderGateway.Create* method should be used with the following parameters:
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```
See full feature description at [*https://api-sandbox.slimpay.net/docs/\#mandate-signature-with-first-direct-debit*](https://api-sandbox.slimpay.net/docs/#mandate-signature-with-first-direct-debit)


#### **Mandate Signature With Recurrent Direct Debit**

In order to sign a mandate with recurrent direct debit *OrderGateway.Create* method should be used with the following configuration:
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```

See full feature description at [*https://api-sandbox.slimpay.net/docs/\#mandate-signature-with-recurrent-direct-debit*](https://api-sandbox.slimpay.net/docs/#mandate-signature-with-recurrent-direct-debit)

#### 

#### **Mandate Signature With Direct Debit and Recurrent Direct Debit**

In order to sign a mandate with recurrent direct debit debit *OrderGateway.Create* method should be used.
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```
See full feature description at [*https://api-sandbox.slimpay.net/docs/\#mandate-signature-with-direct-debit-and-recurrent-direct-debit*](https://api-sandbox.slimpay.net/docs/#mandate-signature-with-direct-debit-and-recurrent-direct-debit)


**Mandate Signature Without Mandate Reference (RUM)**

In order to sign a mandate with recurrent direct debit *OrderGateway.Create* method should be used with *AutoGenReference = false.*
```C#
var orderGateway = slimpayGateway.OrderGateway();

var order = orderGateway.Create(

        new OrderRequest()

        {

          Subscriber = new SubscriberRequest() { Reference =
"subscriber01" },

          Items = new List&lt;OrderItem&gt;()

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

        });
```

See full feature description at [*https://api-sandbox.slimpay.net/docs/\#mandate-signature-without-mandate-reference-rum*](https://api-sandbox.slimpay.net/docs/#mandate-signature-without-mandate-reference-rum)

All the previous Mandate features lead to Order creation with general
information populated (such as order reference, state, payment scheme,
creation date and the marker if the order is started). Also using
*Order.GetUserApprovalLink()* method you are able to retrieve user
approval link following which user can sign created mandate.

See full description of Redirection Flow here
[*https://api-sandbox.slimpay.net/docs/\#redirection-flow*](https://api-sandbox.slimpay.net/docs/#redirection-flow)

### 

### ***Subscriber Login Features***

#### **Subscriber Mandate and Bank Account Management**

In order to let an end-user manage its mandates and bank account details *OrderGateway.Create* method should be used with *SubscriberLoginItem* where *Mode.Type* property set to *SubscriberLoginModeType.ManageMandates*.
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```
See full feature description at [*https://api-sandbox.slimpay.net/docs/\#subscriber-mandate-and-bank-account-management*](https://api-sandbox.slimpay.net/docs/#subscriber-mandate-and-bank-account-management)

#### 

#### **Subscriber Debt Recovery**

In order to let an end-user recover a debt by a card transaction *OrderGateway.Create* method should be used with *SubscriberLoginItem* where *Mode.Type* property set to *SubscriberLoginModeType.RecoverDebt*.
```C#
var orderGateway = slimpayGateway.OrderGateway();
var order = orderGateway.Create(
        new OrderRequest()
        {
          Subscriber = new SubscriberRequest() { Reference = "subscriber01" },
          Items = new List&lt;OrderItem&gt;()
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
        });
```
See full feature description at [*https://api-sandbox.slimpay.net/docs/\#subscriber-debt-recovery*](https://api-sandbox.slimpay.net/docs/#subscriber-debt-recovery)

### ***Other Features***

Using *OrderGateway.Create* method you are also allowed to create some other orders where the next order item types supported:

-   OperationItemType.SignMandate,
-   OperationItemType.DirectDebit,
-   OperationItemType.CardTransaction,
-   OperationItemType.SubscriberLogin,
-   OperationItemType.RecurrentDirectDebit

### Mandate Gateway

Mandate Gateway may be used for retrieving Mandate entites that were created and/or signed before.

#### Find a Mandate

In order to find an existing mandate by reference *MandateGateway.Find* method should be used with reference passed.
```C#
var gateway = slimpayGateway.MandateGateway();
var mandate = gateway.Find("SLMP002958317");
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/alps/v1/\#get-mandates-safe*](https://api-sandbox.slimpay.net/docs/alps/v1/#get-mandates-safe)

#### **Import a Standalone Legacy Mandate**

In order to import a standalone legacy mandate *MandateGateway.Create* method should be used.
```C#
var gateway = slimpayGateway.MandateGateway();
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
})
```
See full feature description at [*https://api-sandbox.slimpay.net/docs/\#import-a-standalone-legacy-mandate*](https://api-sandbox.slimpay.net/docs/#import-a-standalone-legacy-mandate)

### **Direct Debit Gateway**

DirectDebit Gateway should be used to maintain direct debits on Slimpay. The gateway supports both regular and recurrent direct debits.

### ***Direct Debit Features***

#### ***Create a Standalone Direct Debit**

In order to create a standalone direct debit *DirectDebitGateway.CreateStandalone* method should be used with *CreateDirectDebitRequest* passed.
```C#
var gateway = slimpayGateway.DirectDebitGateway();
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
        });
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#create-a-standalone-direct-debit*](https://api-sandbox.slimpay.net/docs/#create-a-standalone-direct-debit)

#### **Update a Direct Debit**

In order to update a direct debit *DirectDebitGateway.UpdateStandalone* method should be used with *UpdateDirectDebitRequest* passed.
```C#
var gateway = slimpayGateway.DirectDebitGateway();
var directDebitUpd = gateway.UpdateStandalone(
        new UpdateDirectDebitRequest()
        {
          Id = directDebit.Id,
          Amount = 200,
          Label = "Your merchant.com subscription updated",
          PaymentReference = "REFERENCE",
          ExecutionDate = new DateTime(2017, 1, 1)
        });
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#update-a-direct-debit*](https://api-sandbox.slimpay.net/docs/#update-a-direct-debit)

These methods result in DirectDebit entities with all the fields populated.

#### 
#### **Create a Standalone Recurrent Direct Debit**

In order to create a standalone reccurrent direct debit *DirectDebitGateway.CreateRecurrent* method should be used with *CreateRecurrentDirectDebitRequest* passed.
```C#
var gateway = slimpayGateway.DirectDebitGateway();
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
        });
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#create-a-standalone-recurrent-direct-debit*](https://api-sandbox.slimpay.net/docs/#create-a-standalone-recurrent-direct-debit)

#### Search Direct Debit Issues (Rtransactions)

In order to search for direct debit issues *DirectDebitIssueGateway.Search* method should be used.
```C#
var gateway = slimpayGateway.DirectDebitIssueGateway();
var issuesContainer = gateway.Search("creditor01");
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#search-direct-debit-issues-rtransactions*](https://api-sandbox.slimpay.net/docs/#search-direct-debit-issues-rtransactions)

### Acknowledge a Direct Debit Issue (Rtransaction)

By acknowledging a direct debit issue, the merchant explicitly changes the execution status of a direct debit
issue. *DirectDebitIssueGateway.Acknowledge* method should be used.
```C#
var gateway = slimpayGateway.DirectDebitIssueGateway();
var issue = gateway.Acknowledge("a47664f5-6855-11e6-999e-000000000000");
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#acknowledge-a-direct-debit-issue-rtransaction*](https://api-sandbox.slimpay.net/docs/#acknowledge-a-direct-debit-issue-rtransaction)

### Refund a Direct Debit by Credit Transfer

In order to refund a direct debit by credit transfer *CreditTransferGateway.Create* method should be used with *CreditTransferRequest* passed.
```C#
var gateway = slimpayGateway.CreditTransferGateway();
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
});
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#refund-a-direct-debit-by-credit-transfer*](https://api-sandbox.slimpay.net/docs/#refund-a-direct-debit-by-credit-transfer)

**Update a Recurrent Direct Debit**

In order to update a standalone reccurrent direct debit *DirectDebitGateway.UpdateRecurrent* method should be used with *UpdateRecurrentDirectDebitRequest* passed.
```C#
var gateway = slimpayGateway.DirectDebitGateway();
var recurrentDirectDebitUpd = gateway.UpdateRecurrent(
        new UpdateRecurrentDirectDebitRequest()
        {
          Id = recurrentDirectDebit.Id,
          Amount = 200,
          Label = "Your merchant.com subscription updated"
        });
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#update-a-recurrent-direct-debit*](https://api-sandbox.slimpay.net/docs/#update-a-recurrent-direct-debit)

These methods result in RecurrentDirectDebit entities with all the fields populated.

### **Document Gateway**

Document Gateway should be used to maintain the documents on Slimpay.

### ***Document Features***

#### **Document Timestamping**

The SlimPay HAPI supports timestamping a PDF document. The purpose of timestamping is to build a proof that a document has existed at the time defined in the timestamp. This proof is then integrated into the PDF document and can be visualized using a compatible PDF reader such as Adobe Acrobat Xi. The SlimPay HAPI stores the timestamped document and the created resource is accessible whenever needed.

This timestamping process consists, behinds the scene, in following the RFC 3161 to retrieve a timestamp from a timestamp authority. In order to timestamp a PDF document DocumentGateway.Create method should be used.
```C#
var gateway = slimpayGateway.DocumentGateway();
var document = gateway.Create(
        new DocumentRequest()
        {
          Timestamped = true,
          BinaryContent = new BinaryContentRequest()
          {
            Content =
"JVBERi0xLjQKJeLjz9MKMiAwIG9iago8PC9MZW5ndGggOTQvRmlsdGVyL0ZsYXRlRGVjb2RlPj5zdHJlYW0KeJwr5HIK4TI2U7AwMFMISeEyUNA1tAAx9N0MFQyNFELSuDQ8UnNy8hXC84tyUhQVwlNTFNxSkxSAqgyNrAyMrYwsFZxdQxSMDAxNNUOygAYYgLS7hnAFcgEA5PgVTwplbmRzdHJlYW0KZW5kb2JqCjQgMCBvYmoKPDwvUGFyZW50IDMgMCBSL0NvbnRlbnRzIDIgMCBSL1R5cGUvUGFnZS9SZXNvdXJjZXM8PC9Qcm9jU2V0IFsvUERGIC9UZXh0IC9JbWFnZUIgL0ltYWdlQyAvSW1hZ2VJXS9Gb250PDwvRjEgMSAwIFI+Pj4+L01lZGlhQm94WzAgMCA1OTUgODQyXT4+CmVuZG9iagoxIDAgb2JqCjw8L0Jhc2VGb250L0hlbHZldGljYS9UeXBlL0ZvbnQvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nL1N1YnR5cGUvVHlwZTE+PgplbmRvYmoKMyAwIG9iago8PC9UeXBlL1BhZ2VzL0NvdW50IDEvS2lkc1s0IDAgUl0+PgplbmRvYmoKNSAwIG9iago8PC9UeXBlL0NhdGFsb2cvUGFnZXMgMyAwIFI+PgplbmRvYmoKNiAwIG9iago8PC9Qcm9kdWNlcihpVGV4dK4gNS40LjEgqTIwMDAtMjAxMiAxVDNYVCBCVkJBIFwoQUdQTC12ZXJzaW9uXCkpL01vZERhdGUoRDoyMDE1MDIxODEyMDMyOSswMScwMCcpL0NyZWF0aW9uRGF0ZShEOjIwMTUwMjE4MTIwMzI5KzAxJzAwJyk+PgplbmRvYmoKeHJlZgowIDcKMDAwMDAwMDAwMCA2NTUzNSBmIAowMDAwMDAwMzMyIDAwMDAwIG4gCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwMDQyMCAwMDAwMCBuIAowMDAwMDAwMTc1IDAwMDAwIG4gCjAwMDAwMDA0NzEgMDAwMDAgbiAKMDAwMDAwMDUxNiAwMDAwMCBuIAp0cmFpbGVyCjw8L1Jvb3QgNSAwIFIvSUQgWzwzZWRhMDI0N2RmYjE4NGZlNDY2ODZkZTEyYWU5OTQyZT48NmQyODVkNzBlYTg0ZGZhZjhhNDAxNzcxOGVlMjM0ZTU+XS9JbmZvIDYgMCBSL1NpemUgNz4+CiVpVGV4dC01LjQuMQpzdGFydHhyZWYKNjY5CiUlRU9GCg=="
          }
        });
```
See full feature descripition at [*https://api-sandbox.slimpay.net/docs/\#document-timestamping*](https://api-sandbox.slimpay.net/docs/#document-timestamping)
