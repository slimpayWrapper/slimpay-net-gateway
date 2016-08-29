using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Documents;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Document
{
  public class DocumentGatewayTests
  {
    [Fact]
    public void Create_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      // Arrange
      SlimpayGateway slimpayGateway = new SlimpayGateway(
       SlimpayEnvironment.SANDBOX,
       "admin_user@gmail.com",
       "usersecret",
       "democreditor01",
       "demosecret01",
       "democreditor"
     );

      // Act
      var document = slimpayGateway.DocumentGateway().Create(
        new DocumentRequest()
        {
          Timestamped = true,
          BinaryContent = new BinaryContentRequest()
          {
            Content = "JVBERi0xLjQKJeLjz9MKMiAwIG9iago8PC9MZW5ndGggOTQvRmlsdGVyL0ZsYXRlRGVjb2RlPj5zdHJlYW0KeJwr5HIK4TI2U7AwMFMISeEyUNA1tAAx9N0MFQyNFELSuDQ8UnNy8hXC84tyUhQVwlNTFNxSkxSAqgyNrAyMrYwsFZxdQxSMDAxNNUOygAYYgLS7hnAFcgEA5PgVTwplbmRzdHJlYW0KZW5kb2JqCjQgMCBvYmoKPDwvUGFyZW50IDMgMCBSL0NvbnRlbnRzIDIgMCBSL1R5cGUvUGFnZS9SZXNvdXJjZXM8PC9Qcm9jU2V0IFsvUERGIC9UZXh0IC9JbWFnZUIgL0ltYWdlQyAvSW1hZ2VJXS9Gb250PDwvRjEgMSAwIFI+Pj4+L01lZGlhQm94WzAgMCA1OTUgODQyXT4+CmVuZG9iagoxIDAgb2JqCjw8L0Jhc2VGb250L0hlbHZldGljYS9UeXBlL0ZvbnQvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nL1N1YnR5cGUvVHlwZTE+PgplbmRvYmoKMyAwIG9iago8PC9UeXBlL1BhZ2VzL0NvdW50IDEvS2lkc1s0IDAgUl0+PgplbmRvYmoKNSAwIG9iago8PC9UeXBlL0NhdGFsb2cvUGFnZXMgMyAwIFI+PgplbmRvYmoKNiAwIG9iago8PC9Qcm9kdWNlcihpVGV4dK4gNS40LjEgqTIwMDAtMjAxMiAxVDNYVCBCVkJBIFwoQUdQTC12ZXJzaW9uXCkpL01vZERhdGUoRDoyMDE1MDIxODEyMDMyOSswMScwMCcpL0NyZWF0aW9uRGF0ZShEOjIwMTUwMjE4MTIwMzI5KzAxJzAwJyk+PgplbmRvYmoKeHJlZgowIDcKMDAwMDAwMDAwMCA2NTUzNSBmIAowMDAwMDAwMzMyIDAwMDAwIG4gCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwMDQyMCAwMDAwMCBuIAowMDAwMDAwMTc1IDAwMDAwIG4gCjAwMDAwMDA0NzEgMDAwMDAgbiAKMDAwMDAwMDUxNiAwMDAwMCBuIAp0cmFpbGVyCjw8L1Jvb3QgNSAwIFIvSUQgWzwzZWRhMDI0N2RmYjE4NGZlNDY2ODZkZTEyYWU5OTQyZT48NmQyODVkNzBlYTg0ZGZhZjhhNDAxNzcxOGVlMjM0ZTU+XS9JbmZvIDYgMCBSL1NpemUgNz4+CiVpVGV4dC01LjQuMQpzdGFydHhyZWYKNjY5CiUlRU9GCg=="
          }
        }).Body;

      // Assert
      Assert.Equal(3, document.Links.Count);
      Assert.NotNull(document.DateCreated);
      Assert.NotNull(document.Reference);
      Assert.NotNull(document.Timestamp);
      Assert.True(document.Timestamped);
    }
  }
}
