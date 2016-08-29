using System;
using System.Collections.Generic;
using RestSharp;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Core.UriTemplates;
using RestRequest = RestSharp.Newtonsoft.Json.RestRequest;

namespace Slimpay.Net.Gateway.Core.Builders
{
  public class HalRequestBuilder : IRequestBuilder
  {
    private IUriTemplateResolver _templateResolver;

    public HalRequestBuilder(IUriTemplateResolver uriTemplateResolver)
    {
      _templateResolver = uriTemplateResolver;
    }

    public IRestRequest BuildRequest(HalLink link, Method httpMethod, IDictionary<string, object> parameters = null, IHalResource request = null)
    {
      IRestRequest restRequest = new RestRequest(httpMethod);
      restRequest.AddHeader("Accept", Constants.SLIMPAY_MEDIA_TYPE);
      restRequest.AddHeader("Content-Type", httpMethod == Method.PATCH ? Constants.SLIMPAY_PATCH_RESPONSE_TYPE : Constants.SLIMPAY_RESPONSE_TYPE);

      if (link != null)
      {
        if (link.IsTemplated && parameters != null)
        {
          var absoluteUri = _templateResolver.ResolveTemplate(link, parameters).Href;
          restRequest.Resource = new Uri(absoluteUri).PathAndQuery;
        }
        else if (parameters != null)
        {
          restRequest.Resource = new Uri(link.Href).PathAndQuery;
          foreach (var parameter in parameters)
          {
            restRequest.AddParameter(parameter.Key, parameter.Value);
          }
        }
        else
        {
          restRequest.Resource = new Uri(link.Href).PathAndQuery;
        }
      }

      if (request != null)
      {
        restRequest.AddJsonBody(request);
        if (httpMethod == Method.PATCH)
        {
          restRequest.Parameters.Find(x => x.Type == ParameterType.RequestBody).Name = Constants.SLIMPAY_PATCH_RESPONSE_TYPE;
        }
      }

      return restRequest;
    }
  }
}
