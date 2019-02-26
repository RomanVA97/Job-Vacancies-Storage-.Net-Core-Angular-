using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testTask.Interfaces;
using testTask.Models.Vacancies;

namespace testTask.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacancies")]
    public class VacanciesController : Controller
    {
        private readonly IVacancyService _vacancyService;
        private readonly ILogger<VacanciesController> _logger;
        public VacanciesController(IVacancyService vacancyService, ILogger<VacanciesController> logger)
        {
            _vacancyService = vacancyService;
            _logger = logger;
        }

        //// GET: api/Vacancies
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public async Task<object> Get(int page, int pageSize)
        {
            var pageCountTask = _vacancyService.GetPageCount(pageSize);
            var elements = (await _vacancyService.Get(page, pageSize))
                .Select(x => new {
                    Id = x.Id,
                    Title = x.Title,
                    OrganizationName = x.OrganizationName,
                    City = x.City,
                    Date = x.Date,
                    WorkingCondition = x.WorkingCondition,
                    IsRemoteWorking = x.IsRemoteWorking
                });
            var pageCount = await pageCountTask;
            return new
            {
                Elements = elements,
                PageCount = pageCount
            };
        }

        // GET: api/Vacancies/5
        [HttpGet("{id}")]
        public async Task<object> Get(string id)
        {
            return await _vacancyService.Get(id);
        }

        // POST: api/Vacancies
        [HttpPost]
        public async Task Post(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return;
            }
            await _vacancyService.Create(model.Title, model.WorkingCondition, model.Description, model.City, model.IsRemoteWorking,
                model.OrganizationName, model.Email, model.CompanyURL, model.PhoneNumber, model.ContactPartner, model.Salary,
                model.CurrencyType);
        }
        
        //// PUT: api/Vacancies/5
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
