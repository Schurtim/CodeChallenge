using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API
{
  [Route("events")]
  public class EventsController : ControllerBase
  {
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
      _eventService = eventService;
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

    [HttpGet]
    [Route("{id}/reserve")]
    public async Task<IActionResult> ReserveHardware(Guid id)
    {
      var @event = await _eventService.GetEvent(id);
      if (@event == null)
      {
        return NotFound();
      }
      return Ok();
    }
  }
}