using WorkShake.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkShake.Repositories
{
  public class StoreRepository : IStoreRepository
  {
    private readonly WorkShakeContext _context;

    public StoreRepository(WorkShakeContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Store>> GetStores()
    {
      return await _context.Store.Include(x => x.ChainStore).ToListAsync();
    }

    public async Task<Store> GetStore(long id)
    {
      return await _context.Store.FindAsync(id);
    }

    public async Task AddStore(Store Store)
    {
      _context.Store.Add(Store);
      await _context.SaveChangesAsync();
    }
  }
}