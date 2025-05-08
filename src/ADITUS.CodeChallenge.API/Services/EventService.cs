using System.Text.Json;
using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services
{
  public class EventService : IEventService
  {
    private readonly IList<Event> _events;
    private HttpClient httpClient = new HttpClient();
    private const string OnlineURL = "https://codechallenge-statistics.azurewebsites.net/api/online-statistics/";
    private const string OnSiteURL = "https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/";

    public EventService()
    {
      _events = new List<Event>
      {
        new Event
        {
          Id = Guid.Parse("7c63631c-18d4-4395-9c1e-886554265eb0"),
          Year = 2024,
          Name = "ADITUS Code Challenge 2024",
          StartDate = new DateTime(2024, 1, 1),
          EndDate = new DateTime(2024, 1, 31),
          Type = EventType.OnSite
        },
        new Event
        {
          Id = Guid.Parse("751fd775-2c8e-48e0-955c-2144008e984a"),
          Year = 2025,
          Name = "ADITUS Code Challenge 2025",
          StartDate = new DateTime(2025, 1, 1),
          EndDate = new DateTime(2025, 1, 15),
          Type = EventType.Hybrid
        },
        new Event
        {
          Id = Guid.Parse("974098e0-9b3f-41d5-80c2-551600ad204a"),
          Year = 2026,
          Name = "ADITUS Code Challenge 2026",
          StartDate = new DateTime(2026, 1, 1),
          EndDate = new DateTime(2026, 1, 18),
          Type = EventType.Online
        },
        new Event
        {
          Id = Guid.Parse("28669572-2b9a-4b2c-ad7e-6434ea8ab761"),
          Year = 2027,
          Name = "ADITUS Code Challenge 2027",
          StartDate = new DateTime(2027, 1, 1),
          EndDate = new DateTime(2027, 1, 11),
          Type = EventType.Online
        },
        new Event
        {
          Id = Guid.Parse("3a17b294-8716-448c-94db-ebf9bf53f1ce"),
          Year = 2027,
          Name = "ADITUS Code Challenge 2027",
          StartDate = new DateTime(2027, 1, 1),
          EndDate = new DateTime(2027, 1, 23),
          Type = EventType.OnSite
        }
      };
    }

    public Task<Event> GetEvent(Guid id)
    {
      var @event = _events.FirstOrDefault(e => e.Id == id);
      return Task.FromResult(@event);
    }

    public Task<IList<Event>> GetEvents()
    {
      return Task.FromResult(_events);
    }

    public async Task<Stats> GetStats(Event @event)
    {
      var stats = new Stats();

      if(@event.Type == EventType.Online || @event.Type == EventType.Hybrid)
      {
        stats.OnlineStats = await FetchOnlineStats(@event.Id);
      }

      if (@event.Type == EventType.OnSite || @event.Type == EventType.Hybrid)
      {
        stats.OnsiteStats = await FetchOnSiteStats(@event.Id);
      }

      return stats;
    }

    private async Task<OnlineStats> FetchOnlineStats(Guid eventId)
    {
      var response = await httpClient.GetAsync(OnlineURL + eventId);

      response.EnsureSuccessStatusCode();
      var responseContent = await response.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<OnlineStats>(responseContent);
    }
    private async Task<OnSiteStats> FetchOnSiteStats(Guid eventId)
    {
      var response = await httpClient.GetAsync(OnSiteURL + eventId);

      response.EnsureSuccessStatusCode();
      var responseContent = await response.Content.ReadAsStringAsync();
      return JsonSerializer.Deserialize<OnSiteStats>(responseContent);
    }
   }
}