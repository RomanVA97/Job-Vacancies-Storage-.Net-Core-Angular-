using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using testTask.Configure;
using testTask.Contexts;
using testTask.Entities;
using testTask.Interfaces;

namespace testTask.Services
{
    public class EventService : IEventService
    {
        private readonly ISocialWebService _socialWebService;
        private readonly IFileStorageService _fileStorage;
        private readonly ILogger<EventService> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IOptions<AppOptions> _appOptions;
        public EventService(ILogger<EventService> logger, AppDbContext appDbContext, IFileStorageService fileStorage,
            ISocialWebService socialWebService, IOptions<AppOptions> appOptions)
        {
            _appOptions = appOptions;
            _socialWebService = socialWebService;
            _fileStorage = fileStorage;
            _logger = logger;
            _appDbContext = appDbContext;
        }


        public async Task Create(string title, string description, string registrationLink, string city, string address, string email, 
            string phoneNumber, DateTime date, IFormFile file)
        {
            try
            {
                var fileNameTask = _fileStorage.Save(file);
                var item = new Event
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = title,
                    Description = description,
                    RegistrationLink = registrationLink,
                    City = city,
                    Address = address,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Date = date
                };
                item.FileName = await fileNameTask;
                await _appDbContext.AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                var message = string.Format("{0} {1} @ {2} #event #.net {3}/{4}/{5}",
                    item.Title, item.City, item.Date, _appOptions.Value.FrontDNS, _appOptions.Value.VacancyDetailPath, item.Id);
                await _socialWebService.SendInformationAsync(message);
                /*
                 встречайте седьмой по счету митап @elixir_lang_mos http://elixirjobs.ru/events/1 !
                 */
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message + e.StackTrace);
                throw new Exception();
            }
        }

        public async Task<ICollection<Event>> Get(int page, int pageSize)
        {
            var result = new List<Event>();
            try
            {
                result = await _appDbContext.Events.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message + e.StackTrace);
                throw new Exception();
            }
            return result;
        }

        public Task<Event> Get(string id)
        {
            return _appDbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetPageCount(int pageSize)
        {
            var count = await _appDbContext.Events.CountAsync();
            var result = count / pageSize;
            if (count % pageSize > 0) result++;
            return result;
        }

    }
}
