using WorkShake.Repositories;
using WorkShake.Models;
using WorkShake.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WorkShake.Services
{
  public class ChainStoreService : IChainStoreService
  {
    private readonly IChainStoreRepository _chainStore;
    private readonly IMapper _mapper;

    public ChainStoreService(IChainStoreRepository chainStore, IMapper mapper)
    {
      _chainStore = chainStore;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ChainStoreWithStoreDTO>> GetChainStores()
    {
      var chainStores = await _chainStore.GetChainStores();
      var result = _mapper.Map<IEnumerable<ChainStoreWithStoreDTO>>(chainStores);
      return result;
    }

    public async Task<ChainStoreWithStoreDTO> GetChainStore(long id)
    {
      var chainStore = await _chainStore.GetChainStore(id);

      if (chainStore == null)
      {
        // TODO see how manage that
        // return NotFound();
      }

      var result = _mapper.Map<ChainStoreWithStoreDTO>(chainStore);
      return result;
    }

    public async Task AddChainStore(ChainStore chainStore)
    {
      await _chainStore.AddChainStore(chainStore);
    }

  }
}