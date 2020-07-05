using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;

namespace WorkShake.Repositories
{
  public interface IUserRepository
  {
    Task<User> GetUserForLogin(string name);
    Task AddUser(User user);
  }
}