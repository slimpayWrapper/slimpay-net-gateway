using System;
using System.IO;
using Newtonsoft.Json;

namespace Slimpay.Net.Gateway.Documents
{
  /// <summary>
  /// Binary content.
  /// </summary>
  public class BinaryContentRequest
  {
    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("contentType")]
    public string ContentType { get; set; }

    [JsonProperty("contentEncoding")]
    public string ContentEncoding { get; set; }

    public void SetContent(Stream stream)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        stream.CopyTo(ms);
        SetContent(ms.ToArray());
      }
    }

    public void SetContent(byte[] bytes)
    {
      Content = Convert.ToBase64String(bytes);
    }

    public override string ToString()
    {
      return string.Format("BinaryContentRequest{contentEncoding='{0}', contentType='{1}', content='{2}'}",
        ContentEncoding, ContentType, Content);
    }
  }
}