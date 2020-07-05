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
  public class StoresController : ControllerBase
  {
    private readonly IStoreService _store;

    public StoresController(IStoreService store)
    {
      _store = store;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreSimpleDTO>>> GetStores()
    {
      return Ok(await _store.GetStores());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StoreSimpleDTO>> GetStore(long id)
    {
      return await _store.GetStore(id);
    }

    [HttpPost]
    public async Task<ActionResult<StoreSimpleDTO>> PostStore(Store store)
    {
      await _store.AddStore(store);
      return CreatedAtAction(nameof(GetStore), new { id = store.Id }, store);
    }
  }
}
