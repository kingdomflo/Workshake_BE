using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShake.Models;
using WorkShake.Models.DTO;
using WorkShake.Repositories;
using AutoMapper;

namespace WorkShake.Services
{
  public class StoreService : IStoreService
  {
    private readonly IStoreRepository _store;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository store, IMapper mapper)
    {
      _store = store;
      _mapper = mapper;
    }

    public async Task<IEnumerable<StoreSimpleDTO>> GetStores()
    {
      var stores = await _store.GetStores();
      var result = _mapper.Map<IEnumerable<StoreSimpleDTO>>(stores);
      return result;
    }

    public async Task<StoreSimpleDTO> GetStore(long id)
    {
      var store = await _store.GetStore(id);

      if (store == null)
      {
        // TODO see how manage that
        // return NotFound();
      }

      var result = _mapper.Map<StoreSimpleDTO>(store);

      return result;
    }

    public async Task AddStore(Store store)
    {
      await _store.AddStore(store);
    }
  }
}