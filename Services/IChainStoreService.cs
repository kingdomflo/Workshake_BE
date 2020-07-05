using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;
using WorkShake.Models.DTO;

namespace WorkShake.Services
{
  public interface IChainStoreService
  {
    Task<IEnumerable<ChainStoreWithStoreDTO>> GetChainStores();
    Task<ChainStoreWithStoreDTO> GetChainStore(long id);
    Task AddChainStore(ChainStore chainStore);
  }
}