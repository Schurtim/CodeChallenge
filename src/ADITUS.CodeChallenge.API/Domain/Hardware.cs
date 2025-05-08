namespace ADITUS.CodeChallenge.API.Domain
{
  public class Hardware
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public HardwareType Type { get; set; }
    public List<HardwareReservation> HardwareReservations { get; set; } = new List<HardwareReservation>();
  }
}
