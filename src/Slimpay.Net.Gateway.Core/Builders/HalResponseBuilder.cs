using RestSharp;
using Slimpay.Net.Gateway.Core.Json.Serializers;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Builders
{
  public class HalResponseBuilder : IResponseBuilder
  {
    private readonly IHalJsonSerializer _halJsonSerializer;

    public HalResponseBuilder(IHalJsonSerializer halJsonSerializer)
    {
      _halJsonSerializer = halJsonSerializer;
    }

    public Response<T> BuildResponse<T>(IRestResponse restResponse)
      where T : IHalResource, new()
    {
      if (restResponse.ErrorException != null)
      {
        var error = new HalErrorResponse(restResponse.StatusCode, restResponse.ErrorMessage);
        return new Response<T>(error, restResponse.StatusCode, restResponse.ErrorMessage);
      }

      var result = _halJsonSerializer.Deserialize<T>(restResponse.Content);
      return new Response<T>(result);
    }
  }
}
