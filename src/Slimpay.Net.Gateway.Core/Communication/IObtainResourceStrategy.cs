using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  public interface IObtainResourceStrategy
  {
    bool IsInitialized { get; }

    void SetLinks(HalResource links);

    HalLink GetResourceByRel(string rel, HalResource linksContainer = null);
  }
}