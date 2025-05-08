using ADITUS.CodeChallenge.API.Controllers;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API
{
  [Route("events")]
  public class EventsController : ControllerBase
  {
    private readonly IEventService _eventService;
    private readonly IHardwareService _hardwareService;

    public EventsController(IEventService eventService, IHardwareService hardwareService)
    {
      _eventService = eventService;
      _hardwareService = hardwareService;
    }

    /// <summary>
    /// Gibt eine Übersicht der Events zurück, ohne Statistiken.
    /// </summary>
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetEvents()
    {
      var events = await _eventService.GetEvents();
      return Ok(events);
    }
    
    /// <summary>
    /// Gibt das Event für die übergebene ID zurück, inkl. Statistiken.
    /// </summary>
    /// <param name="id">ID des Events</param>
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetEvent(Guid id)
    {
      var @event = await _eventService.GetEvent(id);
      if (@event == null)
      {
        return NotFound();
      }
      var stats = await _eventService.GetStats(@event);
      return Ok(new
      {
        Event = @event,
        Stats = stats
      });
    }

    [HttpPost]
    [Route("{id}/hardware")]
    public async Task<IActionResult> ReserveHardware(Guid id, [FromBody]HardwareReservationRequest request)
    {
      var @event = await _eventService.GetEvent(id);
      if (@event == null)
      {
        return NotFound();
      }
      if (DateTime.Now.AddDays(7*4) > @event.StartDate)
      {
        throw new InvalidOperationException("Reservierungszeitraum unterschritten.");
      }
      if (@event.HardwareReservations.Any())
      {
        throw new InvalidOperationException("Reservierung schon getätigt.");
      }
      var availableHardware = _hardwareService.GetHardware(request.Type, request.Amount, @event.StartDate, @event.EndDate);
      foreach (var hardware in availableHardware)
      {
        _hardwareService.ReserveHardware(hardware, @event);
      }
      return Ok();
    }
  }
}