using System;
using Microsoft.AspNetCore.Mvc;
using WorkShake.Services;
using Microsoft.AspNetCore.Diagnostics;

[ApiController]
public class ErrorController : ControllerBase
{

  // [Route("/error")]
  // public IActionResult Error() => Problem();

  [Route("/error")]
  public IActionResult Error()
  {
    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
    Console.WriteLine("lol"+context.Error.Message);
    return Problem(title: context.Error.Message);
  }

}