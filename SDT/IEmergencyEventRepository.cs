public interface IEmergencyEventRepository
{
    Task<IEnumerable<EmergencyEvent>> GetAllEventsAsync();
    Task<EmergencyEvent> GetEventByIdAsync(int id);
    Task AddEventAsync(EmergencyEvent emergencyEvent);
    Task UpdateEventAsync(EmergencyEvent emergencyEvent);
    Task DeleteEventAsync(int id);
}
