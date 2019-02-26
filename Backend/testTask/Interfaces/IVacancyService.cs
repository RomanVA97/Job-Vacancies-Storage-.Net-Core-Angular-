using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testTask.Entities;
using testTask.Enums;

namespace testTask.Interfaces
{
    public interface IVacancyService
    {
        Task<ICollection<Vacancy>> Get(int page, int pageSize);
        Task<Vacancy> Get(string id);
        Task<int> GetPageCount(int pageSize);
        Task Create(string title, WorkingConditions workingCondition, string description, string city, bool isRemoteWorking,
            string organizationName, string email, string companyURL, string phoneNumber, string contactPartner,
            decimal salary, CurrencyTypes currencyType);
    }
}
