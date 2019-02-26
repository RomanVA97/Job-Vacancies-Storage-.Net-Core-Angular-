using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testTask.Entities;

namespace testTask.Interfaces
{
    public interface IEventService
    {
        Task<ICollection<Event>> Get(int page, int pageSize);
        Task<Event> Get(string id);
        Task<int> GetPageCount(int pageSize);
        Task Create(string title, string description, string registrationLink, string city,
            string address, string email, string phoneNumber, DateTime date, IFormFile file);
    }
}
