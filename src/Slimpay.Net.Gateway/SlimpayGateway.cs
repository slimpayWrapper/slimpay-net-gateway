using Slimpay.Net.Gateway.App;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Auth;
using Slimpay.Net.Gateway.Core.Builders;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Json.Serializers;
using Slimpay.Net.Gateway.Core.UriTemplates;

using Slimpay.Net.Gateway.Creditors;
using Slimpay.Net.Gateway.CreditTransfers;
using Slimpay.Net.Gateway.DirectDebitIssues;
using Slimpay.Net.Gateway.DirectDebits;
using Slimpay.Net.Gateway.Documents;
using Slimpay.Net.Gateway.Mandates;
using Slimpay.Net.Gateway.OrderItems;
using Slimpay.Net.Gateway.Orders;

namespace Slimpay.Net.Gateway
{
  /// <summary>
  /// Gateway to the slimpay api.
  /// </summary>
  public class SlimpayGateway
  {
    private IConfiguration _configuration;
    private IHttpClient _http;
    private IObtainResourceStrategy _obtainResourceStrategy;

    public SlimpayGateway(SlimpayEnvironment environment, string adminLogin, string adminPwd, string appName,
      string appSecret, string creditorReference)
    {
      _configuration = new Configuration(environment, adminLogin, adminPwd, appName, appSecret, creditorReference);
      _http = new HalHttpClient(_configuration, new HalRequestBuilder(new UriTemplateResolver()),
        new HalResponseBuilder(new HalJsonSerializer()));
      _obtainResourceStrategy = new HalObtainResourceStrategy();
    }

    /// <summary>
    /// Return the underlying configuration.
    /// </summary>
    public virtual IConfiguration Configuration
    {
      get { return _configuration; }
    }

    /// <summary>
    /// Return an authentication gateway.
    /// </summary>
    public virtual AuthenticationGateway AuthenticationGateway()
    {
      return new AuthenticationGateway(_http);
    }

    /// <summary>
    /// Return an order gateway.
    /// </summary>
    public virtual OrderGateway OrderGateway()
    {
      return new OrderGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return a document gateway.
    /// </summary>
    public virtual DocumentGateway DocumentGateway()
    {
      return new DocumentGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return an order item gateway.
    /// </summary>
    public virtual OrderItemGateway OrderItemGateway()
    {
      return new OrderItemGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return a creditor gateway.
    /// </summary>
    public virtual CreditorGateway CreditorGateway()
    {
      return new CreditorGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return a direct debit gateway.
    /// </summary>
    public virtual DirectDebitGateway DirectDebitGateway()
    {
      return new DirectDebitGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return a mandate gateway.
    /// </summary>
    public virtual MandateGateway MandateGateway()
    {
      return new MandateGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return an App gateway.
    /// </summary>
    public virtual AppGateway AppGateway()
    {
      return new AppGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Return a direct debit issue gateway.
    /// </summary>
    public virtual DirectDebitIssueGateway DirectDebitIssueGateway()
    {
      return new DirectDebitIssueGateway(_configuration, _http, _obtainResourceStrategy);
    }

    /// <summary>
    /// Returns the  credit transfer gateway.
    /// </summary>
    public virtual CreditTransferGateway CreditTransferGateway()
    {
      return new CreditTransferGateway(_configuration, _http, _obtainResourceStrategy);
    }
  }
}