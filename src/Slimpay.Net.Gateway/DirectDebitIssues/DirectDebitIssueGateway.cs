using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebitIssues
{
  public class DirectDebitIssueGateway : HalResourceGateway
  {
    private const string SEARCH_DIRECT_DEBIT_ISSUES_PATH = "https://api.slimpay.net/alps#search-direct-debit-issues";
    private const string GET_DIRECT_DEBIT_ISSUES_PATH = "https://api.slimpay.net/alps#get-direct-debit-issues";
    private const string ACK_DIRECT_DEBIT_ISSUES_PATH = "https://api.slimpay.net/alps#ack-direct-debit-issue";

    public DirectDebitIssueGateway(IConfiguration configuration, IHttpClient http,
      IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Searches direct debit issues for the specified creditor.
    /// </summary>
    /// <param name="creditor">The creditor.</param>
    /// <returns></returns>
    public Response<DirectDebitIssuesContainer> Search(string creditor)
    {
      var parameters = new Dictionary<string, object>
      {
        {"creditorReference", string.IsNullOrEmpty(creditor) ? Configuration.CreditorReference : creditor}
      };

      return Get<DirectDebitIssuesContainer>(SEARCH_DIRECT_DEBIT_ISSUES_PATH, parameters);
    }

    /// <summary>
    /// Acknowledges the specified issue.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Response<DirectDebitIssue> Acknowledge(string id)
    {
      var issue = Get(id).Body;
      return Get<DirectDebitIssue>(ACK_DIRECT_DEBIT_ISSUES_PATH,null, issue);
    }

    /// <summary>
    /// Gets the specified direct debit issue.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public Response<DirectDebitIssue> Get(string id)
    {
      var parameters = new Dictionary<string, object>
      {
        {"id", string.IsNullOrEmpty(id) ? string.Empty : id}
      };

      return Get<DirectDebitIssue>(GET_DIRECT_DEBIT_ISSUES_PATH, parameters);
    }
  }
}
