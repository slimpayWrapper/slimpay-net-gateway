using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Core.Communication
{
  public class HalObtainResourceStrategy : IObtainResourceStrategy
  {
    public bool IsInitialized
    {
      get
      {
        return _links != null && _links.Count > 0;
      }
    }

    private static HalLinkCollection _links;

    public void SetLinks(HalResource links)
    {
      if (links != null && links.Links.Count > 0)
      {
        _links = new HalLinkCollection();
        _links.AddRange(links.Links);
      }
    }

    /// <summary>
    /// Navigates to the resource specified by relative path
    /// </summary>
    /// <param name="rel"></param>
    /// <returns></returns>
    public HalLink GetResourceByRel(string rel, HalResource linksContainer = null)
    {
      HalLink result = null;

      if (!string.IsNullOrEmpty(rel))
      {
        if (linksContainer != null)
        {
          result = linksContainer.Links.GetLink(rel);
        }
        if (result == null && _links != null)
        {
          result = _links.GetLink(rel);
        }
      }

      return result;
    }
  }
}
