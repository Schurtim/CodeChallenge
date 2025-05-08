using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services
{
  public class HardwareService : IHardwareService
  {
    public List<Hardware> GetHardware(HardwareType type, int amount, DateTime availableFrom, DateTime availableUntil)
    {
      var hardware = HardwareStore.Hardware
        .Where(x => x.Type == type)
        .Where(x => x.HardwareReservations.All(y => !DoesOverlap(y, availableFrom, availableUntil)))
        .ToArray();
      if (hardware.Length < amount)
      {
        throw new ArgumentException($"Not enough hardware available. Requested: {amount}, Available: {hardware.Length}");
      }
      return hardware
        .Take(amount)
        .ToList();
    }

    public void ReserveHardware(Hardware hardware, Event @event)
    {
      var reservation = new HardwareReservation
      {
        Event = @event,
        Hardware = hardware,
        EventId = @event.Id,
        HardwareId = hardware.Id,
      };
      hardware.HardwareReservations.Add(reservation);
      @event.HardwareReservations.Add(reservation);
    }
    private bool DoesOverlap(HardwareReservation reservation, DateTime from, DateTime until)
    {
      return reservation.Event.StartDate < until && from < reservation.Event.EndDate;
    }
  }
}
