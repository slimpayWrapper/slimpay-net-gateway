namespace Slimpay.Net.Gateway.Core.Models
{
  public interface IHalResource
  {
    HalLinkCollection Links { get; set; }

    bool IsNew { get; set; }
  }
}
