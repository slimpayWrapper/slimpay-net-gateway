using System;
using System.Linq;
using Slimpay.Net.Gateway;
using Slimpay.Net.Gateway.App;
using Slimpay.Net.Gateway.Core;
using Xunit;

namespace Slimpay.Net.Getaway.Tests.Apps
{
  // Note: tests here are commented out just because you need a user with admin scope to access these API.
  // Fill in admin credentials below and uncomment if needed to test. admin.user@gmail.com is fake one.
  public class AppGatewayTests
  {
    private AppGateway _appGateway;

    [Fact]
    public void FindAll_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      /*var gateway = GetGateway();
      var apps = gateway.All().Body;
      Assert.Equal(1, apps.Apps.Count());
      Assert.Equal(1, apps.Links.Count);*/
    }

    [Fact]
    public void FindAppByName_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      /*var gateway = GetGateway();
      var app = gateway.Find("hbp53fd0lygb").Body;
      Assert.Equal("hbp53fd0lygb", app.Name);*/
    }

    [Fact]
    public void PatchApp_WhenSlimpayGatewayConfiguredToUseSandbox_ReturnsExpectedResponse()
    {
      /*var gateway = GetGateway();
      var value =  Guid.NewGuid().ToString();
      var app = gateway.Patch("hbp53fd0lygb", new AppRequest{NotifyUrl = value}).Body;
      Assert.Equal("hbp53fd0lygb", app.Name);
      Assert.Equal(value, app.NotifyUrl);*/
    }

    private AppGateway GetGateway()
    {
      if (_appGateway == null)
      {
        SlimpayGateway slimpayGateway = new SlimpayGateway(
          SlimpayEnvironment.SANDBOX,
        "admin.user@gmail.com",
        "adminpassword",
        "democreditor01",
        "demosecret01",
        "gfp53ff0l123"
       );

        _appGateway = slimpayGateway.AppGateway();
      }

      return _appGateway;
    }
  }
}