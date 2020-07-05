using WorkShake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkShake.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly WorkShakeContext _context;

    public UserRepository(WorkShakeContext context)
    {
      _context = context;
    }

    public async Task<User> GetUserForLogin(string name)
    {
      return await _context.User.SingleAsync(x => x.Name == name);
    }

    public async Task AddUser(User user)
    {
      _context.User.Add(user);
      await _context.SaveChangesAsync();
    }
  }
}