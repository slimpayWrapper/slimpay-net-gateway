using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway
{
  public class HalResourceGateway : IResourceGateway
  {
    private IHttpClient _httpClient;
    private IObtainResourceStrategy _obtainResourceStrategy;

    protected IConfiguration Configuration { get; private set; }
    protected bool IsAdminMode { get; set; }

    public HalResourceGateway(IConfiguration configuration, IHttpClient httpClient, IObtainResourceStrategy obtainResourceStrategy)
    {
      Configuration = configuration;
      _httpClient = httpClient;
      _obtainResourceStrategy = obtainResourceStrategy;
    }

    public Response<TResponse> Get<TResponse>(string rel, Dictionary<string, object> parameters, HalResource links = null) where TResponse : IHalResource, new()
    {
      FixAuthenticationStatus();
      HalLink link = ObtainResourceHref(new HalLink() { Rel = rel }, links);
      Response<TResponse> response = _httpClient.Get<TResponse>(link, parameters);
      return response;
    }

    public Response<TResponse> Patch<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      FixAuthenticationStatus();
      HalLink link = ObtainResourceHref(new HalLink() { Rel = rel }, links);
      Response<TResponse> response = _httpClient.Patch<TRequest, TResponse>(link, parameters, requestObject);
      return response;
    }

    public Response<TResponse> Post<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      FixAuthenticationStatus();
      HalLink link = ObtainResourceHref(new HalLink() { Rel = rel }, links);
      Response<TResponse> response = _httpClient.Post<TRequest, TResponse>(link, parameters, requestObject);
      return response;
    }

    public Response<TResponse> Put<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      FixAuthenticationStatus();
      HalLink link = ObtainResourceHref(new HalLink() { Rel = rel }, links);
      Response<TResponse> response = _httpClient.Put<TRequest, TResponse>(link, parameters, requestObject);
      return response;
    }

    private void FixAuthenticationStatus()
    {
      if (!_httpClient.IsAuthenticated || IsAdminMode != _httpClient.IsAdminMode)
      {
        if (IsAdminMode)
        {
          _httpClient.AuthenticateAsAdmin();
        }
        else
        {
          _httpClient.Authenticate();
        }
      }
    }

    private HalLink ObtainResourceHref(HalLink link, HalResource resource)
    {
      HalLink result;

      if (link != null && !string.IsNullOrEmpty(link.Rel) && string.IsNullOrEmpty(link.Href))
      {
        if (!_obtainResourceStrategy.IsInitialized)
        {
          _obtainResourceStrategy.SetLinks(_httpClient.Get<HalResource>(null, null).Body);
        }
        result = _obtainResourceStrategy.GetResourceByRel(link.Rel, resource);
      }
      else
      {
        result = link;
      }

      return result;
    }
  }
}
