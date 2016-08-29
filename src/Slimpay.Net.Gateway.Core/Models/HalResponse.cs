using System.Net;

namespace Slimpay.Net.Gateway.Core.Models
{
  /// <summary>
  /// Wrap a response from slimpay.
  /// </summary>
  public class Response<T>
  {
    public Response(T body)
    {
      this.Body = body;
    }

    public Response(T body, HttpStatusCode httpStatusCode)
    {
      this.Body = body;
      this.HttpStatusCode = httpStatusCode;
    }

    public Response(HalErrorResponse error, HttpStatusCode httpStatusCode, string httpStatusMessage)
    {
      this.Error = error;
      this.HttpStatusCode = httpStatusCode;
      this.HttpStatusMessage = httpStatusMessage;
    }

    public virtual T Body { get; private set; }

    public virtual HalErrorResponse Error { get; private set; }

    public virtual HttpStatusCode HttpStatusCode { get; private set; }

    public virtual string HttpStatusMessage { get; private set; }

    public virtual bool Success
    {
      get
      {
        return this.Error == null;
      }
    }
  }
}