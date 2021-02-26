using EventTickets.Models;
using EventTickets.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository) {

            this._eventRepository = eventRepository;
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> GetById(Guid eventId) 
        {
            var result = await _eventRepository.GetEventByIdAsync(eventId);
            return Ok(new EventDto
            {
                Artist = result.Artist,
                CategoryId = result.CategoryId,
                CategoryName = result.Category.Name,
                Name = result.Name,
                Date = result.Date,
                Description = result.Description,
                EventId = result.EventId,
                Price = result.Price

            });
    
        }

        //api/events?categoryId=fsdfsdf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> Get([FromQuery] Guid categoryId)
        {
            var result = await _eventRepository.GetEventByCategoryIdAsync(categoryId);
            return Ok(result.Select(x=> new EventDto
            {
                Artist = x.Artist,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                Name = x.Name,
                Date = x.Date,
                Description = x.Description,
                EventId = x.EventId,
                Price = x.Price 
            }));

        }


    }
}
