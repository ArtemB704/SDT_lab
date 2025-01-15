public class EmergencyEventRepository : IEmergencyEventRepository
{
    private readonly DbContext _context;

    public EmergencyEventRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EmergencyEvent>> GetAllEventsAsync()
    {
        return await _context.Set<EmergencyEvent>().ToListAsync();
    }

    public async Task<EmergencyEvent> GetEventByIdAsync(int id)
    {
        return await _context.Set<EmergencyEvent>().FindAsync(id);
    }

    public async Task AddEventAsync(EmergencyEvent emergencyEvent)
    {
        _context.Set<EmergencyEvent>().Add(emergencyEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEventAsync(EmergencyEvent emergencyEvent)
    {
        _context.Set<EmergencyEvent>().Update(emergencyEvent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        var emergencyEvent = await GetEventByIdAsync(id);
        if (emergencyEvent != null)
        {
            _context.Set<EmergencyEvent>().Remove(emergencyEvent);
            await _context.SaveChangesAsync();
        }
    }
}
