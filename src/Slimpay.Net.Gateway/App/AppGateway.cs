using System.Collections.Generic;
using System.Linq;
using Slimpay.Net.Gateway.Core;
using Slimpay.Net.Gateway.Core.Communication;
using Slimpay.Net.Gateway.Core.Models;

namespace Slimpay.Net.Gateway.App
{
  public class AppGateway : HalResourceGateway
  {
    public const string GET_APPS_PATH = "https://api.slimpay.net/alps#get-apps";
    public const string GET_APP_PATH = "https://api.slimpay.net/alps#get-app";
    public const string PATCH_APP = "https://api.slimpay.net/alps#patch-app";

    public AppGateway(IConfiguration configuration, IHttpClient http, IObtainResourceStrategy obtainResourceStrategy)
      : base(configuration, http, obtainResourceStrategy)
    {
    }

    /// <summary>
    /// Returns all apps
    /// </summary>
    public Response<AppContainer> All()
    {
      IsAdminMode = true;
      return Get<AppContainer>(GET_APPS_PATH, new Dictionary<string, object>());
    }

    /// <summary>
    /// Returns the specified app.
    /// </summary>
    /// <param name="name">The name.</param>
    public Response<App> Find(string name)
    {
      IsAdminMode = true;
      var apps = Get<AppContainer>(GET_APPS_PATH, null).Body;
      var app = apps.Apps.First(x => x.Name == name);
      return Get<App>(app.Links.GetLink("self").Rel, null, app);
    }

    /// <summary>
    /// Patches the specified app.
    /// </summary>
    /// <param name="name">The app name.</param>
    /// <param name="request">The patch request.</param>
    /// <returns></returns>
    public Response<App> Patch(string name, AppRequest request)
    {
      IsAdminMode = true;
      var app = Find(name).Body;
      if (app != null)
      {
        return Patch<AppRequest, App>(PATCH_APP, request, null, app);
      }
      return null;
    }
  }
}