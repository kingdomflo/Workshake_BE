using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;
using WorkShake.Models.DTO;
using AutoMapper;
using WorkShake.Repositories;
using WorkShake.Utils;
using System;
using System.Net.Http;

namespace WorkShake.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _user;
    private readonly IMapper _mapper;
    private readonly PasswordHasher passwordHasher;

    public UserService(IUserRepository user, IMapper mapper)
    {
      _user = user;
      _mapper = mapper;
      passwordHasher = new PasswordHasher();
    }

    public async Task<UserSimpleDTO> Login(User user)
    {
      User userLogged = await _user.GetUserForLogin(user.Name);

      if (userLogged == null)
      {
        // TODO see how manage that
        // return NotFound();
      }

      if (!passwordHasher.Check(userLogged.Password, user.Password).Verified)
      {
        Console.WriteLine("bad password");
        // TODO see how manage bad password
        // return NotFound();

        // throw new ArgumentException("Bad password");
        throw new HttpResponseException()
        {
          Status = 404,
          Value = "Bad password"
        };

      }

      var result = _mapper.Map<UserSimpleDTO>(userLogged);
      return result;
    }

    public async Task Registration(User user)
    {
      user.Password = passwordHasher.Hash(user.Password);
      await _user.AddUser(user);
    }
  }
}