public interface IEventRepository
{
    List<Event> GetAllEvents();
    Event GetEventById(int id);
    void AddEvent(Event newEvent);
    void UpdateEvent(Event updatedEvent);
    void DeleteEvent(int id);
}
