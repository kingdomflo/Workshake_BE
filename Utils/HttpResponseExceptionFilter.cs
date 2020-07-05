using Microsoft.AspNetCore.Mvc.Filters;
using WorkShake.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WorkShake.Utils
{
  public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
  {
    public int Order { get; set; } = int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (context.Exception is HttpResponseException exception)
      {
        Console.WriteLine("hello error");
        context.Result = new ObjectResult(exception.Value)
        {
          StatusCode = exception.Status,
          Value = exception.Value
        };
        context.ExceptionHandled = true;
      }
    }
  }
}