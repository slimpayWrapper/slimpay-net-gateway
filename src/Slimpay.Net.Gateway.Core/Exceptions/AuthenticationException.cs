using System;
using System.Net;

namespace Slimpay.Net.Gateway.Core.Exceptions
{
  /// <summary>
  /// Is thrown when an authentication failure occurs.
  /// </summary>
  public class AuthenticationException : Exception
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    public AuthenticationException(HttpStatusCode httpStatusCode, string httpStatusMessage)
      : base("Cannot authentify to Slimpay API")
    {
      this.HttpStatusCode = httpStatusCode;
      this.HttpStatusMessage = httpStatusMessage;
    }

    public virtual HttpStatusCode HttpStatusCode { get; private set; }

    public virtual string HttpStatusMessage { get; private set; }
  }
}