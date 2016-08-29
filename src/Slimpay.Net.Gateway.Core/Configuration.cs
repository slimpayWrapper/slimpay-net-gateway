namespace Slimpay.Net.Gateway.Core
{
  /// <summary>
  /// Slimpay configuration.
  /// </summary>
  public class Configuration : IConfiguration
  {
    public Configuration(
      SlimpayEnvironment environment,
      string adminLogin,
      string adminPwd,
      string appName,
      string appSecret,
      string creditorReference)
    {
      this.Environment = environment;
      this.AdminLogin = adminLogin;
      this.AdminPwd = adminPwd;
      this.AppName = appName;
      this.AppSecret = appSecret;
      this.CreditorReference = creditorReference;
    }

    public virtual SlimpayEnvironment Environment { get; private set; }

    public virtual string AdminLogin { get; private set; }

    public virtual string AdminPwd { get; private set; }

    public virtual string AppName { get; private set; }

    public virtual string AppSecret { get; private set; }

    public virtual string CreditorReference { get; private set; }
  }
}