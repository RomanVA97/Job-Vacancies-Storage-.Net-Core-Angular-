using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testTask.Interfaces;
using testTask.Models.Events;

namespace testTask.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventsController> _logger;
        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            _logger = logger;
            _eventService = eventService;
        }


        //// GET: api/Events
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public async Task<object> Get(int page, int pageSize)
        {
            var pageCountTask = _eventService.GetPageCount(pageSize);
            var elements = (await _eventService.Get(page, pageSize))
                .Select(x => new {
                    Id = x.Id,
                    Title = x.Title,
                    Address = x.Address,
                    Date = x.Date,
                    City = x.City
                });
            var pageCount = await pageCountTask;
            return new
            {
                Elements = elements,
                PageCount = pageCount
            };
        }

        // GET: api/Events/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get(string id)
        {
            return await _eventService.Get(id);
        }

        // POST: api/Events
        [HttpPost]
        public async Task Post(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return;
            }
            await _eventService.Create(model.Title, model.Description, model.RegistrationLink, model.City, model.Address,
                model.Email, model.PhoneNumber, model.Date, model.File);
        }
        
        //// PUT: api/Events/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
