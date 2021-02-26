using EventTickets.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.Repositories
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetAsync();
        Task<Category> GetByIdAsync(Guid categoryId);
    }
}
