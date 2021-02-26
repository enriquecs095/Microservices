using EventTickets.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.Repositories
{
    public interface IEventRepository
    {

        Task<Event> GetEventByIdAsync(Guid eventId);

        Task<IReadOnlyList<Event>> GetEventByCategoryIdAsync(Guid categoryId);
    }
}
