namespace Slimpay.Net.Gateway.Core.Auth
{
  public interface IAuthenticationGateway
  {
    Token AdminToken();

    Token AppToken();
  }
}