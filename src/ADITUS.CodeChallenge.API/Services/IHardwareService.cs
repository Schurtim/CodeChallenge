using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services
{
  public interface IHardwareService
  {
    List<Hardware> GetHardware(HardwareType type, int amount, DateTime availableFrom, DateTime availableUntil);
    void ReserveHardware(Hardware hardware, Event @event);
  }
}
