using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  public interface IRestApi
  {
    Response<T> Get<T>(HalLink link, Dictionary<string, object> parameters) where T : IHalResource, new();

    Response<TResponse> Patch<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();

    Response<TResponse> Post<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();

    Response<TResponse> Put<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new();
  }
}