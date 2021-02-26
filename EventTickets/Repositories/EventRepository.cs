using EventTickets.Contexts;
using EventTickets.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _context;
        public EventRepository(EventCatalogDbContext context) {
            this._context = context;
        }

        public async Task<IReadOnlyList<Event>> GetEventByCategoryIdAsync(Guid categoryId)
        {
            return await _context.Events.Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(Guid eventId)
        {
            return await _context.Events.Include(x=>x.Category).FirstOrDefaultAsync(x => x.EventId == eventId);
        }


    }
}
