using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.Orders
{
  /// <summary>
  /// Order gateway.
  /// </summary>
  public class OrderGateway : HalResourceGateway
  {
    private const string GET_ORDERS_PATH = "https://api.slimpay.net/alps#get-orders";
    private const string CREATE_ORDERS_PATH = "https://api.slimpay.net/alps#create-orders";

    public OrderGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Find an order by reference.
    /// </summary>
    public Response<Order> Find(string reference)
    {
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters["reference"] = reference;
      parameters["creditorReference"] = Configuration.CreditorReference;
      return Get<Order>(GET_ORDERS_PATH, parameters);
    }

    /// <summary>
    /// Create an order.
    /// </summary>
    public Response<Order> Create(OrderRequest orderRequest)
    {
      if (orderRequest.Creditor == null)
      {
        orderRequest.Creditor = new CreditorRequest()
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<OrderRequest, Order>(CREATE_ORDERS_PATH, orderRequest, null);
    }
  }
}