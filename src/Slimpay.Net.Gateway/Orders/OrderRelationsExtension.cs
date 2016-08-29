using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.Orders
{
  public static class OrderRelationsExtension
  {
    private const string USER_APPROVAL_LINK = "https://api.slimpay.net/alps#user-approval";
    private const string EXTENDED_USER_APPROVAL_LINK = "https://api.slimpay.net/alps#extended-user-approval";
    private const string GET_DIRECT_DEBIT_LINK = "https://api.slimpay.net/alps#get-direct-debit";

    public static HalLink GetUserApprovalLink(this Order order)
    {
      return GetLinkByRelation(order, USER_APPROVAL_LINK);
    }

    public static HalLink GetExtendedUserApprovalLink(this Order order)
    {
      return GetLinkByRelation(order, EXTENDED_USER_APPROVAL_LINK);
    }

    public static HalLink GetDirectDebitLink(this Order order)
    {
      return GetLinkByRelation(order, GET_DIRECT_DEBIT_LINK);
    }

    private static HalLink GetLinkByRelation(Order order, string relation)
    {
      HalLink result = null;
      if (order.Links != null && order.Links.Count > 0)
      {
        result = order.Links.GetLink(relation);
      }

      return result;
    }
  }
}
