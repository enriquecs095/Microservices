using EventTickets.ShoppingBasket.Contexts;
using EventTickets.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.ShoppingBasket.Repositories
{
    public class BasketLineRepository : IBasketLineRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public BasketLineRepository(ShoppingBasketDbContext shoppingBasketDbContext) {
            this._shoppingBasketDbContext = shoppingBasketDbContext;

        }

        public async Task<BasketLine> AddAsync(Guid basketId, BasketLine basketLine)
        {
            basketLine.BasketLineId = Guid.NewGuid();
            basketLine.BasketId = basketId;
            await _shoppingBasketDbContext.AddAsync(basketLine);
            return basketLine;
        }

        public async Task<IReadOnlyList<BasketLine>> GetBasketLinesAsync(Guid basketId)
        {
            return await _shoppingBasketDbContext.BasketLines.Include(x => x.Event).Where(x => x.BasketId == basketId).ToListAsync();

        }
    }
}
