using System.Text.Json.Serialization;

namespace ADITUS.CodeChallenge.API.Domain
{
  public class HardwareReservation
  {
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonIgnore]
    public Event Event { get; set; }
    public Guid EventId { get; set; }

    [JsonIgnore]
    public Hardware Hardware { get; set; }
    public Guid HardwareId { get; set; }
    public bool IsPending { get; set; } = true;
  }
}