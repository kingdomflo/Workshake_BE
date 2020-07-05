using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;
using WorkShake.Models.DTO;

namespace WorkShake.Services
{
  public interface IStoreService
  {
    Task<IEnumerable<StoreSimpleDTO>> GetStores();
    Task<StoreSimpleDTO> GetStore(long id);
    Task AddStore(Store store);
  }
}