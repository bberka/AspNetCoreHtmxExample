using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters;


//FOR MVC
// public class HtmxRequestActionFilter : ActionFilterAttribute
// {
//   public override void OnActionExecuting(ActionExecutingContext context) {
//     var isHtmxRequest = context.HttpContext.Request.IsHtmx();
//     if (!isHtmxRequest) {
//       context.Result = new NoContentResult();
//     }
//   }
//   
// }


//FOR RAZOR PAGES
[AttributeUsage(AttributeTargets.Class)]
public class HtmxRequestFragmentFilter : Attribute,IAsyncPageFilter
{

  public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) {
    return Task.CompletedTask;
  }
  

  public Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next) {
    //Returns not found if request is not from htmx
    //Remember this can easily be bypassed by changing the request header to htmx headers
    var isHtmxRequest = context.HttpContext.Request.IsHtmx();
    if (!isHtmxRequest) {
      context.Result = new NotFoundResult();
      return Task.CompletedTask;
    }
    return next();
  }
}