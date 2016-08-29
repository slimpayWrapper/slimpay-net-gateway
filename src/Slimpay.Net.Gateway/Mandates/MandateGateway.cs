using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.Mandates
{
  public class MandateGateway : HalResourceGateway
  {
    private const string CREATE_MANDATES_PATH = "https://api.slimpay.net/alps#create-mandates";
    private const string GET_MANDATES_PATH = "https://api.slimpay.net/alps#get-mandates";

    public MandateGateway(IConfiguration configuration, IHttpClient httpClient,
      IObtainResourceStrategy obtainResourceStrategy) : base(configuration, httpClient, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Creates the specified mandate.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns> Mandate</returns>
    public Response<Mandate> Create(CreateMandateRequest request)
    {
      if (request.Creditor == null)
      {
        request.Creditor = new Creditor()
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<CreateMandateRequest, Mandate>(CREATE_MANDATES_PATH, request, null);
    }

    /// <summary>
    /// Find an order by reference.
    /// </summary>
    public Response<Mandate> Find(string reference)
    {
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters["reference"] = reference;
      parameters["creditorReference"] = Configuration.CreditorReference;

      return Get<Mandate>(GET_MANDATES_PATH, parameters);
    }
  }
}