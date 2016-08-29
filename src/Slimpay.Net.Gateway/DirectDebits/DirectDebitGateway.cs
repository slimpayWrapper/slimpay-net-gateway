using System.Collections.Generic;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;
using Slimpay.Net.Gateway.Creditors;

namespace Slimpay.Net.Gateway.DirectDebits
{
  public class DirectDebitGateway : HalResourceGateway
  {
    private const string GET_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#get-direct-debits";
    private const string GET_RECURRENT_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#get-recurrent-direct-debits";
    private const string CREATE_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#create-direct-debits";
    private const string CREATE_RECURRENT_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#create-recurrent-direct-debits";
    private const string UPDATE_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#patch-direct-debit";
    private const string UPDATE_RECURRENT_DIRECT_DEBIT_PATH = "https://api.slimpay.net/alps#patch-recurrent-direct-debit";

    public DirectDebitGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Get one direct debit.
    /// </summary>
    public Response<DirectDebit> GetStandalone(string id)
    {
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters.Add("id", id);
      return Get<DirectDebit>(GET_DIRECT_DEBIT_PATH, parameters);
    }

    /// <summary>
    /// Get one recurrent direct debit.
    /// </summary>
    public Response<RecurrentDirectDebit> GetRecurrent(string id)
    {
      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters.Add("id", id);
      return Get<RecurrentDirectDebit>(GET_RECURRENT_DIRECT_DEBIT_PATH, parameters);
    }

    /// <summary>
    /// Create a direct debit.
    /// </summary>
    public Response<DirectDebit> CreateStandalone(CreateDirectDebitRequest createRequest)
    {
      if (createRequest.Creditor == null)
      {
        createRequest.Creditor = new CreditorRequest()
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<CreateDirectDebitRequest, DirectDebit>(CREATE_DIRECT_DEBIT_PATH, createRequest, null);
    }

    /// <summary>
    /// Create a recurrent direct debit.
    /// </summary>
    public Response<RecurrentDirectDebit> CreateRecurrent(CreateRecurrentDirectDebitRequest createRequest)
    {
      if (createRequest.Creditor == null)
      {
        createRequest.Creditor = new CreditorRequest()
        {
          Reference = Configuration.CreditorReference
        };
      }

      return Post<CreateRecurrentDirectDebitRequest, RecurrentDirectDebit>(CREATE_RECURRENT_DIRECT_DEBIT_PATH, createRequest, null);
    }

    /// <summary>
    /// Patch a direct debit of which ExecutionStatus property is either ToProcess or ToReplay.
    /// </summary>
    public Response<DirectDebit> UpdateStandalone(UpdateDirectDebitRequest updateRequest)
    {
      Response<DirectDebit> directDebit = GetStandalone(updateRequest.Id);
      if (directDebit.Success)
      {
        directDebit = Patch<UpdateDirectDebitRequest, DirectDebit>(UPDATE_DIRECT_DEBIT_PATH, updateRequest, null, directDebit.Body);
      }
      return directDebit;
    }

    /// <summary>
    /// Patch a recurrent direct debit of which the activated property is true.
    /// </summary>
    public Response<RecurrentDirectDebit> UpdateRecurrent(UpdateRecurrentDirectDebitRequest updateRequest)
    {
      Response<RecurrentDirectDebit> directDebit = GetRecurrent(updateRequest.Id);
      if (directDebit.Success)
      {
        directDebit = Patch<UpdateRecurrentDirectDebitRequest, RecurrentDirectDebit>(UPDATE_RECURRENT_DIRECT_DEBIT_PATH, updateRequest, null, directDebit.Body);
      }
      return directDebit;
    }
  }
}