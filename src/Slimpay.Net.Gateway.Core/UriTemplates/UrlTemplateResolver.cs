using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Models;
using Tavis.UriTemplates;

namespace Slimpay.Net.Gateway.Core.UriTemplates
{
  public sealed class UriTemplateResolver : IUriTemplateResolver
  {
    public HalLink ResolveTemplate(HalLink link, IDictionary<string, object> parameters)
    {
      var template = new UriTemplate(link.Href);
      foreach (var parameter in parameters)
      {
        template.SetParameter(parameter.Key, parameter.Value);
      }

      return new HalLink(template.Resolve());
    }
  }
}
