using Newtonsoft.Json.Converters;

namespace Slimpay.Net.Gateway.Core.Json.Converters
{
  public class SlimpayDateTimeConverter : IsoDateTimeConverter
  {
    public SlimpayDateTimeConverter()
    {
      DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffzz00";
    }
  }
}
