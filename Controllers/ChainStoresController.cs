using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkShake.Models;
using WorkShake.Models.DTO;
using AutoMapper;
using WorkShake.Services;

namespace WorkShake.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ChainStoresController : ControllerBase
  {
    private readonly IChainStoreService _chainStore;

    public ChainStoresController(IChainStoreService chainStore)
    {
      _chainStore = chainStore;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChainStoreWithStoreDTO>>> GetChaineStores()
    {
      return Ok(await _chainStore.GetChainStores());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ChainStoreWithStoreDTO>> GetChaineStore(long id)
    {
      return await _chainStore.GetChainStore(id);
    }

    [HttpPost]
    public async Task<ActionResult<ChainStoreSimpleDTO>> PostChaineStore(ChainStore chainStore)
    {
      await _chainStore.AddChainStore(chainStore);
      return CreatedAtAction(nameof(GetChaineStore), new { id = chainStore.Id }, chainStore);
    }
  }
}
