using System.Collections.Generic;

namespace Slimpay.Net.Gateway.Core
{
  /// <summary>
  /// Slimpay environment.
  /// </summary>
  public sealed class SlimpayEnvironment
  {
    public static readonly SlimpayEnvironment SANDBOX = new SlimpayEnvironment("SANDBOX", InnerEnum.SANDBOX, "oauth/token", "oauth/token", "https://api-sandbox.slimpay.net");

    private static readonly IList<SlimpayEnvironment> valueList = new List<SlimpayEnvironment>();

    static SlimpayEnvironment()
    {
      valueList.Add(SANDBOX);
    }

    public enum InnerEnum
    {
      SANDBOX
    }

    private readonly string nameValue;
    private readonly int ordinalValue;
    private readonly InnerEnum innerEnumValue;
    private static int nextOrdinal = 0;

    private string adminAuthenticationUrl;
    private string authenticationUrl;
    private string entryUrl;

    internal SlimpayEnvironment(string name, InnerEnum innerEnum, string adminAuthenticationUrl, string authenticationUrl, string entryUrl)
    {
      this.adminAuthenticationUrl = adminAuthenticationUrl;
      this.authenticationUrl = authenticationUrl;
      this.entryUrl = entryUrl;

      nameValue = name;
      ordinalValue = nextOrdinal++;
      innerEnumValue = innerEnum;
    }

    public string AdminAuthenticationUrl
    {
      get
      {
        return adminAuthenticationUrl;
      }
    }

    public string AuthenticationUrl
    {
      get
      {
        return authenticationUrl;
      }
    }

    public string EntryUrl
    {
      get
      {
        return entryUrl;
      }
    }

    public static IList<SlimpayEnvironment> values()
    {
      return valueList;
    }

    public InnerEnum InnerEnumValue()
    {
      return innerEnumValue;
    }

    public int ordinal()
    {
      return ordinalValue;
    }

    public override string ToString()
    {
      return nameValue;
    }

    public static SlimpayEnvironment valueOf(string name)
    {
      foreach (SlimpayEnvironment enumInstance in SlimpayEnvironment.values())
      {
        if (enumInstance.nameValue == name)
        {
          return enumInstance;
        }
      }
      throw new System.ArgumentException(name);
    }
  }

}