using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Attributes;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.App
{
  public class AppContainer : HalResource
  {
    [HalEmbedded("apps")]
    public IEnumerable<App> Apps { get; set; }
  }
}
