namespace Slimpay.Net.Gateway.Core.Json.Serializers
{
  public interface IHalJsonSerializer
  {
    T Deserialize<T>(string jsonContent) where T: new();
  }
}
