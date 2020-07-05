using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;

namespace WorkShake.Repositories
{
  public interface IStoreRepository
  {
    Task<IEnumerable<Store>> GetStores();
    Task<Store> GetStore(long id);
    Task AddStore(Store store);
  }
}