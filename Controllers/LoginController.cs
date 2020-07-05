using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkShake.Models;
using WorkShake.Models.DTO;
using WorkShake.Services;

namespace WorkShake.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    private readonly IUserService _user;

    public LoginController(IUserService user)
    {
      _user = user;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserSimpleDTO>>> Login(User user)
    {
      return Ok(await _user.Login(user));
    }

    [HttpPost]
    public async Task<ActionResult<UserSimpleDTO>> Registration(User user)
    {
      await _user.Registration(user);

      // maybe rework the return for the password
      return CreatedAtAction(nameof(Login), user);
    }
  }
}
