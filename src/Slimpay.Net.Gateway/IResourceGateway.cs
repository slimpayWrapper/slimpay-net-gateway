using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway
{
  public interface IResourceGateway
  {
    Response<TResponse> Get<TResponse>(string rel, Dictionary<string, object> parameters, HalResource links = null) where TResponse : IHalResource, new();

    Response<TResponse> Patch<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();

    Response<TResponse> Post<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();

    Response<TResponse> Put<TRequest, TResponse>(string rel, TRequest requestObject, Dictionary<string, object> parameters, HalResource links = null)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();
  }
}