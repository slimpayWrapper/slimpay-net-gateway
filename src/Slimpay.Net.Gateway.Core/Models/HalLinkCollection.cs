using System.Collections.Generic;
using System.Linq;

namespace Slimpay.Net.Gateway.Core.Models
{
  public class HalLinkCollection : List<HalLink>
  {
    public HalLink GetLink(string rel)
    {
      return (from link in this where link.Rel == rel select link).FirstOrDefault();
    }

    public bool HasLink(string rel)
    {
      return this.Any(l => l.Rel == rel);
    }
  }
}