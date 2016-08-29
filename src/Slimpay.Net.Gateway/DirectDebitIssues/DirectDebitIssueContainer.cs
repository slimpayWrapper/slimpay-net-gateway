using System.Collections.Generic;
using Slimpay.Net.Gateway.Core.Attributes;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.DirectDebitIssues
{
  public class DirectDebitIssuesContainer : HalResourceContainer
  {
    [HalEmbedded("directDebitIssues")]
    public IEnumerable<DirectDebitIssue> DirectDebitIssues { get; set; }
  }
}