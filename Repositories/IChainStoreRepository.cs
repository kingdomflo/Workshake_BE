using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;

namespace WorkShake.Repositories
{
  public interface IChainStoreRepository
  {
    Task<IEnumerable<ChainStore>> GetChainStores();
    Task<ChainStore> GetChainStore(long id);
    Task AddChainStore(ChainStore chainStore);
  }
}