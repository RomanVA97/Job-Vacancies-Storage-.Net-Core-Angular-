using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testTask.Configure;
using testTask.Contexts;
using testTask.Entities;
using testTask.Enums;
using testTask.Interfaces;

namespace testTask.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly ISocialWebService _socialWebService;
        private readonly ILogger<VacancyService> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IOptions<AppOptions> _appOptions;
        public VacancyService(ILogger<VacancyService> logger, AppDbContext appDbContext, 
            ISocialWebService socialWebService, IOptions<AppOptions> appOptions)
        {
            _appOptions = appOptions;
            _socialWebService = socialWebService;
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public async Task Create(string title, WorkingConditions workingCondition, string description, string city, 
            bool isRemoteWorking, string organizationName, string email, string companyURL, string phoneNumber, 
            string contactPartner, decimal salary, CurrencyTypes currencyType)
        {
            try
            {
                var item = new Vacancy
                {
                    Title = title,
                    WorkingCondition = workingCondition,
                    Description = description,
                    City = city,
                    IsRemoteWorking = isRemoteWorking,
                    OrganizationName = organizationName,
                    Email = email,
                    CompanyURL = companyURL,
                    PhoneNumber = phoneNumber,
                    ContactPartner = contactPartner,
                    Salary = salary,
                    CurrencyType = currencyType,
                    Date = DateTime.Now
                };
                await _appDbContext.AddAsync(item);
                await _appDbContext.SaveChangesAsync();
                var message = string.Format("{0} @ {1} #job #.net {2}/{3}/{4}", 
                    item.Title, item.OrganizationName, _appOptions.Value.FrontDNS, _appOptions.Value.VacancyDetailPath, item.Id);
                await _socialWebService.SendInformationAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message + e.StackTrace);
                throw new Exception();
            }
        }

        public async Task<ICollection<Vacancy>> Get(int page, int pageSize)
        {
            var result = new List<Vacancy>();
            try
            {
                result = await _appDbContext.Vacancies.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message + e.StackTrace);
                throw new Exception();
            }
            return result;
        }

        public Task<Vacancy> Get(string id)
        {
            return _appDbContext.Vacancies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetPageCount(int pageSize)
        {
            var count = await _appDbContext.Vacancies.CountAsync();
            var result = count / pageSize;
            if (count % pageSize > 0) result++;
            return result;
        }
    }
}
