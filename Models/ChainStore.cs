using System.Collections.Generic;

namespace WorkShake.Models
{
  public class ChainStore
  {
    public long Id { get; set; }
    public string Label { get; set; }
    // will be an image - base64?
    public string Logo { get; set; }

    public List<Store> Stores { get; set; }
  }
}
