using Microsoft.EntityFrameworkCore;
using WorkShake.Models;
using System;
using WorkShake.Utils;

namespace WorkShake.Models
{
  public static class WorkShakeContextExtension
  {

    public static void EnsureSeedDataForContext(this WorkShakeContext context)
    {
      PasswordHasher passwordHasher = new PasswordHasher();
      context.ChainStore.RemoveRange(context.Set<ChainStore>());
      context.SaveChanges();

      ChainStore quick = new ChainStore()
      {
        Label = "Quick",
        Logo = "some image"
      };

      ChainStore macDo = new ChainStore()
      {
        Label = "MacDo",
        Logo = "other image"
      };

      context.ChainStore.Add(quick);
      context.ChainStore.Add(macDo);
      context.SaveChanges();

      Store quickAnspach = new Store()
      {
        Label = "Anspach",
        WorkShake = true,
        ChainStore = quick,
        Latitude = 50.849174M,
        Longitude = 4.350923M
      };

      Store quickCentral = new Store()
      {
        Label = "Central",
        WorkShake = true,
        ChainStore = quick,
        Latitude = 50.844817M,
        Longitude = 4.356239M
      };

      context.Store.Add(quickAnspach);
      context.Store.Add(quickCentral);
      context.SaveChanges();

      User samy = new User()
      {
        Name = "Samy Gnu",
        Email = "samy@gnu.no",
        Password = "c@rIBoU"
      };

      samy.Password = passwordHasher.Hash(samy.Password);

      context.User.Add(samy);
      context.SaveChanges();

      Console.WriteLine("DB init finish");
    }

  }
}