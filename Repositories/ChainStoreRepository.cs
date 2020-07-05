using WorkShake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkShake.Repositories
{
  public class ChainStoreRepository : IChainStoreRepository
  {
    private readonly WorkShakeContext _context;

    public ChainStoreRepository(WorkShakeContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<ChainStore>> GetChainStores()
    {
      return await _context.ChainStore.Include(x => x.Stores).ToListAsync();
    }

    public async Task<ChainStore> GetChainStore(long id)
    {
      return await _context.ChainStore.FindAsync(id);
    }

    public async Task AddChainStore(ChainStore ChainStore)
    {
      _context.ChainStore.Add(ChainStore);
      await _context.SaveChangesAsync();
    }
  }
}