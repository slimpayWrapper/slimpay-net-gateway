using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Auth;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.Documents
{
  /// <summary>
  /// Documents gateway.
  /// </summary>
  public class DocumentGateway : HalResourceGateway
  {
    private const string CREATE_DOCUMENTS_PATH = "https://api.slimpay.net/alps#create-documents";

    public DocumentGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Create a document.
    /// </summary>
    public Response<Document> Create(DocumentRequest documentRequest)
    {
      if (documentRequest.Creditor == null)
      {
        documentRequest.Creditor = new CreditorRequest()
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<DocumentRequest, Document>(CREATE_DOCUMENTS_PATH, documentRequest, null);
    }
  }
}