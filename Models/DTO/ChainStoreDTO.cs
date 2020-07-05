using System.Collections.Generic;

namespace WorkShake.Models.DTO
{

  public class ChainStoreSimpleDTO
  {
    public long Id { get; set; }
    public string Label { get; set; }
    public string Logo { get; set; }
  }

  public class ChainStoreWithStoreDTO
  {
    public long Id { get; set; }
    public string Label { get; set; }
    public string Logo { get; set; }
    public List<StoreWithoutChainStoreDTO> Stores { get; set; }
  }

}