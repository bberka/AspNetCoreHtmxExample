using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHtmxExample.RazorPages;

namespace AspNetCoreHtmxExample.RazorPages.Pages.Fragments;

[HtmxRequestFragmentFilter]
public class Counter : PageModel
{
  public static int StaticCount = 0;

  [BindProperty]
  public int Count { get; set; } = 0;

  public void OnGet() {
    StaticCount++;
    Count += 2;
  }
}