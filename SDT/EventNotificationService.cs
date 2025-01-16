public class EventNotificationService
{
    private readonly IEventRepository _eventRepository;

    public EventNotificationService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public List<Event> GetCriticalEvents()
    {
        var allEvents = _eventRepository.GetAllEvents();
        return allEvents.Where(e => e.Name.Contains("Критичний")).ToList();
    }

    public string NotifyCitizens(Event criticalEvent)
    {
        // Реалізація логіки надсилання повідомлень
        return $"Оповіщення: {criticalEvent.Name} у місці {criticalEvent.Location}";
    }
}
