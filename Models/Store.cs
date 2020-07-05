namespace WorkShake.Models
{
  public class Store
  {
    public long Id { get; set; }
    public string Label { get; set; }
    // Better algo later to see if the Milk Shake machin work
    // Will not be a bool but a long
    // percentage chance of the machine working
    public bool WorkShake { get; set; }

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public long ChainStoreId { get; set; }
    public ChainStore ChainStore { get; set; }
  }
}
