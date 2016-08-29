using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Auth;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  public interface IHttpClient
  {
    Token Token { get; }
    bool IsAuthenticated { get; }
    bool IsAdminMode { get; }

    void Authenticate();
    void AuthenticateAsAdmin();

    Response<T> Get<T>(HalLink link, Dictionary<string, object> parameters) where T : IHalResource, new();

    Response<TResponse> Post<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource;

    Response<TResponse> Patch<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource;

    Response<TResponse> Put<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource;
  }
}