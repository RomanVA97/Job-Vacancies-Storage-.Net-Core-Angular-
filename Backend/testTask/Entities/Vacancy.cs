using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testTask.Enums;

namespace testTask.Entities
{
    public class Vacancy
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public WorkingConditions WorkingCondition { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public bool IsRemoteWorking { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public string CompanyURL { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPartner { get; set; }
        public decimal Salary { get; set; }
        public CurrencyTypes CurrencyType { get; set; }
        public DateTime Date { get; set; }
    }
}
