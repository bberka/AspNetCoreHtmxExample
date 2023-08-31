using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Filters;

namespace WebApplication1.Pages.Fragments;

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