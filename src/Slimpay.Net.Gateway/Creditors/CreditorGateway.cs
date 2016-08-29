using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Creditors
{
  /// <summary>
  /// Creditor gateway.
  /// </summary>
  public class CreditorGateway : HalResourceGateway
  {
    private const string GET_CREDITORS_PATH = "https://api.slimpay.net/alps#get-creditors";

    public CreditorGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    public Response<Creditor> Find()
    {
      var parameters = new Dictionary<string, object>();
      parameters.Add("reference", Configuration.CreditorReference);

      return Get<Creditor>(GET_CREDITORS_PATH, parameters);
    }
  }
}