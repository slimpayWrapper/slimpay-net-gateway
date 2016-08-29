using System.Collections.Generic;
using RestSharp;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Builders
{
  public interface IRequestBuilder
  {
    IRestRequest BuildRequest(HalLink link, Method httpMethod, IDictionary<string, object> parameters = null, IHalResource request = null);
  }
}
