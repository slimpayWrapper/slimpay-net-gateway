using System.Collections.Generic;
using RestSharp;
using Slimpay.Net.Gateway.Core.Builders;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  public class HalApi : IRestApi
  {
    private IRestClient _restClient;
    private IRequestBuilder _requestBuilder;
    private IResponseBuilder _responseBuilder;

    public HalApi(IRestClient restClient, IRequestBuilder requestBuilder, 
      IResponseBuilder responseBuilder)
    {
      _restClient = restClient;
      _requestBuilder = requestBuilder;
      _responseBuilder = responseBuilder;
    }

    public Response<T> Get<T>(HalLink link, Dictionary<string, object> parameters)
      where T : IHalResource, new()
    {
      var restRequest = _requestBuilder.BuildRequest(link, Method.GET, parameters);
      var apiResponse = _restClient.Execute(restRequest);
      return _responseBuilder.BuildResponse<T>(apiResponse);
    }

    public Response<TResponse> Post<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource
    {
      return ExecuteWithBody<TRequest, TResponse>(link, Method.POST, parameters, request);
    }

    public Response<TResponse> Patch<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource
    {
      return ExecuteWithBody<TRequest, TResponse>(link, Method.PATCH, parameters, request);
    }

    public Response<TResponse> Put<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource
    {
      return ExecuteWithBody<TRequest, TResponse>(link, Method.PUT, parameters, request);
    }

    private Response<TResponse> ExecuteWithBody<TRequest, TResponse>(HalLink link, Method method, Dictionary<string, object> parameters, TRequest request)
      where TResponse : IHalResource, new()
      where TRequest : IHalResource
    {
      var restRequest = _requestBuilder.BuildRequest(link, method, parameters, request);
      var apiResponse = _restClient.Execute(restRequest);
      return _responseBuilder.BuildResponse<TResponse>(apiResponse);
    }
  }
}
