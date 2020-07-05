namespace WorkShake.Models.DTO
{

  public class StoreSimpleDTO
  {
    public long Id { get; set; }
    public string Label { get; set; }
    public bool WorkShake { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public ChainStoreSimpleDTO ChainStore { get; set; }
  }

  public class StoreWithoutChainStoreDTO
  {
    public long Id { get; set; }
    public string Label { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool WorkShake { get; set; }
  }

}