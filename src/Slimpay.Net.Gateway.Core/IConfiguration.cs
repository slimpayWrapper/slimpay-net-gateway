namespace Slimpay.Net.Gateway.Core
{
  public interface IConfiguration
  {
    string AdminLogin { get; }

    string AdminPwd { get; }

    string AppName { get; }

    string AppSecret { get; }

    string CreditorReference { get; }

    SlimpayEnvironment Environment { get; }
  }
}