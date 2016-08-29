using RestSharp;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Builders
{
  public interface IResponseBuilder
  {
    Response<T> BuildResponse<T>(IRestResponse restResponse)
      where T : IHalResource, new();
  }
}
