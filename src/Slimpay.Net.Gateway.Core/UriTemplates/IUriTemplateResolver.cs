using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.UriTemplates
{
  public interface IUriTemplateResolver
  {
    HalLink ResolveTemplate(HalLink link, IDictionary<string, object> parameters);
  }
}
