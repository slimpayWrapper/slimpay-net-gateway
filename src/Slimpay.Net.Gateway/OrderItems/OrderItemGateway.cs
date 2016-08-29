using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;

namespace Slimpay.Net.Gateway.OrderItems
{
  /// <summary>
  /// Order item gateway.
  /// </summary>
  public class OrderItemGateway : HalResourceGateway
  {
    private const string GET_ORDERS_PATH = "https://api.slimpay.net/alps#get-order-items";
    private const string CREATE_ORDERS_PATH = "https://api.slimpay.net/alps#create-order-items";

    public OrderItemGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }
  }
}