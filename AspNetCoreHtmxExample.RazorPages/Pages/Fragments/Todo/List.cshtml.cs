using AspNetCoreHtmxExample.RazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreHtmxExample.RazorPages.Pages.Fragments.Todo;

public class List : PageModel
{
  [FromForm(Name = "name")]
  [BindProperty]
  public string? Name { get; set; }
  
  
  
  public void OnGet() {
    if (TodoHolder.Todos.Count == 0) {
      var todo = new TodoItem
        { Title = "Learn HTMX" };
      TodoHolder.Todos.Add(todo);
      todo = new TodoItem
        { Title = "Learn AspNetCore" };
      TodoHolder.Todos.Add(todo);
    }
  }
    
  public void OnPost() {
    if(string.IsNullOrEmpty(Name)) return;
     var todo = new TodoItem
       { Title = Name };
      TodoHolder.Todos.Add(todo);
  }

  public void OnDelete() {
    if(string.IsNullOrEmpty(Name)) return;
    var todo = TodoHolder.Todos.FirstOrDefault(t => t.Title == Name);
    if (todo != null) {
      TodoHolder.Todos.Remove(todo);
    }
  }

  public void OnPut() {
    if(string.IsNullOrEmpty(Name)) return;
    var todo = TodoHolder.Todos.FirstOrDefault(t => t.Title == Name);
    if (todo != null) {
      todo.IsComplete = !todo.IsComplete;
    }
  }
  
  
}