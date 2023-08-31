using Htmx;

namespace WebApplication1.Helpers;

public static class Helper
{
  public static string GetLayout(this HttpRequest httpRequest) {
    return httpRequest.IsHtmx()
             ? "_PartialLayout"
             : "_PageLayout";
  }

  /// <summary>
  /// This header taken by site.js to override the page title on navigation change
  /// </summary>
  /// <param name="httpResponse"></param>
  /// <param name="title"></param>
  public static void AddTitleOverrideHeader(this HttpResponse httpResponse,string title) {
    httpResponse.Headers.Add("Override-Page-Title", GetTitle(title));
  }

  public static string GetTitle(string pageName) {
    return pageName + " - Web App";
  }
}