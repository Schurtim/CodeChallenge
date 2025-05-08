using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Controllers
{
  public class HardwareReservationRequest
  {
    public HardwareType Type { get; set; }
    public int Amount { get; set; }
  }
}
