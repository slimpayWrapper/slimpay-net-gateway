using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Slimpay.Net.Gateway.Core.Auth;
using Slimpay.Net.Gateway.Core.Builders;
using Slimpay.Net.Gateway.Core.Exceptions;
using Slimpay.Net.Gateway.Core.Json.Serializers;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  /// <summary>
  /// Facade to http requests.
  /// </summary>
  public class HalHttpClient : IHttpClient
  {
    public Token Token { get; private set; }
    public bool IsAuthenticated { get; private set; }
    public bool IsAdminMode { get; private set; }

    private IConfiguration _configuration;
    private IRequestBuilder _requestBuilder;
    private IResponseBuilder _responseBuilder;

    private IRestApi _restApi;


    public HalHttpClient(IConfiguration configuration,
      IRequestBuilder requestBuilder,
      IResponseBuilder responseBuilder)
    {
      _configuration = configuration;
      _requestBuilder = requestBuilder;
      _responseBuilder = responseBuilder;
    }

    public void Authenticate()
    {
      ResetState();
      var link = new HalLink(_configuration.Environment.AuthenticationUrl);
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters.Add("scope", "api");
      var result = GetToken(link, new HttpBasicAuthenticator(_configuration.AppName, _configuration.AppSecret), parameters);
      if (result.Success && result.Body != null && !string.IsNullOrEmpty(result.Body.AccessToken))
      {
        Token = result.Body;
        IsAuthenticated = true;
        InitRestApi(Token);
      }
      else
      {
        throw new AuthenticationException(result.HttpStatusCode, result.HttpStatusMessage);
      }
    }

    public void AuthenticateAsAdmin()
    {
      ResetState();
      var link = new HalLink(_configuration.Environment.AdminAuthenticationUrl);
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters.Add("scope", "api_admin");
      var result = GetToken(link, new HttpBasicAuthenticator(string.Format("{0}#{1}", _configuration.CreditorReference, _configuration.AdminLogin), _configuration.AdminPwd), parameters);
      if (result.Success && result.Body != null && !string.IsNullOrEmpty(result.Body.AccessToken))
      {
        Token = result.Body;
        IsAuthenticated = true;
        IsAdminMode = true;
        InitRestApi(Token);
      }
      else
      {
        throw new AuthenticationException(result.HttpStatusCode, result.HttpStatusMessage);
      }
    }

    public Response<T> Get<T>(HalLink link, Dictionary<string, object> parameters) where T : IHalResource, new()
    {
      return _restApi.Get<T>(link, parameters);
    }

    public Response<TResponse> Post<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      return _restApi.Post<TRequest, TResponse>(link, parameters, request);
    }

    public Response<TResponse> Patch<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      return _restApi.Patch<TRequest, TResponse>(link, parameters, request);
    }

    public Response<TResponse> Put<TRequest, TResponse>(HalLink link, Dictionary<string, object> parameters, TRequest request)
      where TRequest : IHalResource
      where TResponse : IHalResource, new()
    {
      return _restApi.Put<TRequest, TResponse>(link, parameters, request);
    }

    private Response<Token> GetToken(HalLink link, IAuthenticator authenticator, Dictionary<string, object> parameters)
    {
      return GetAuthApi(authenticator).Post<HalResource, Token>(link, parameters, null);
    }

    private HalApi GetAuthApi(IAuthenticator authenticator)
    {
      var authRestClient = new RestClient(_configuration.Environment.EntryUrl)
      {
        Authenticator = authenticator
      };

      var authRequestBuilder = new HalAuthRequestBuilder();
      var responseBuilder = new HalResponseBuilder(new HalJsonSerializer());

      return new HalApi(authRestClient, authRequestBuilder, responseBuilder);
    }

    private void InitRestApi(Token token)
    {
      var restClient = new RestClient(_configuration.Environment.EntryUrl)
      {
        Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token.AccessToken, "Bearer")
      };
      var requestBuilder = _requestBuilder;
      var responseBuilder = _responseBuilder;

      _restApi = new HalApi(restClient, requestBuilder, responseBuilder);
    }

    private void ResetState()
    {
      IsAdminMode = false;
      IsAuthenticated = false;
      Token = null;
    }
  }
}