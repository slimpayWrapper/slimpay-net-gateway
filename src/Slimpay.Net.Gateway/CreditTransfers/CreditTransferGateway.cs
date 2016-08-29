using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.CreditTransfers
{
  /// <summary>
  /// CreditTransferGateway class
  /// </summary>
  /// <seealso cref="Slimpay.Net.Gateway.HalResourceGateway" />
  public class CreditTransferGateway : HalResourceGateway
  {
    public const string CREATE_CREDIT_TRANSFERS_PATH = "https://api.slimpay.net/alps#create-credit-transfers";

    public CreditTransferGateway(IConfiguration configuration, IHttpClient httpClient, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, httpClient, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Creates the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns></returns>
    public Response<CreditTransfer> Create(CreditTransferRequest request)
    {
      if (request.Creditor == null)
      {
        request.Creditor = new Creditor
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<CreditTransferRequest, CreditTransfer>(CREATE_CREDIT_TRANSFERS_PATH, request, null);
    }
  }
}