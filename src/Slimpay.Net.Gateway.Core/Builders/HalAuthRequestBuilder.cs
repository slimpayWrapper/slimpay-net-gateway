using System;
using System.Collections.Generic;
using RestSharp;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Builders
{
  public class HalAuthRequestBuilder : IRequestBuilder
  {
    public IRestRequest BuildRequest(HalLink link, Method httpMethod, IDictionary<string, object> parameters = null, IHalResource request = null)
    {
      if (link == null || string.IsNullOrEmpty(link.Href))
      {
        throw new ArgumentNullException("RequestBuilder: link is not defined");
      }

      var restRequest = new RestRequest(link.Href, httpMethod);

      restRequest.AddHeader("Accept", Constants.SLIMPAY_RESPONSE_TYPE);
      restRequest.AddHeader("Content-Type", Constants.SLIMPAY_RESPONSE_TYPE);

      restRequest.AddQueryParameter("grant_type", "client_credentials");
      foreach (var parameter in parameters)
      {
        restRequest.AddQueryParameter(parameter.Key, parameter.Value.ToString());
      }

      return restRequest;
    }
  }
}
