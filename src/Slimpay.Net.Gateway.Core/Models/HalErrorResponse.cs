using System.Net;

namespace Slimpay.Net.Gateway.Core.Models
{
  /// <summary>
  /// Slimpay error resource.
  /// </summary>
  public class HalErrorResponse
  {
    public HalErrorResponse()
    {
    }

    public HalErrorResponse(HttpStatusCode code, string message)
    {
      this.Code = code;
      this.Message = message;
    }

    public virtual HttpStatusCode Code {get; private set;}

    public virtual string Message {get; private set;}

    public override string ToString()
    {
      return "Error{" + "code='" + Code.ToString() + '\'' + ", message='" + Message + '\'' + '}';
    }
  }
}