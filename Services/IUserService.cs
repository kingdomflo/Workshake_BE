using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;
using WorkShake.Models.DTO;

namespace WorkShake.Services
{
  public interface IUserService
  {
    Task<UserSimpleDTO> Login(User user);
    Task Registration(User user);
  }
}