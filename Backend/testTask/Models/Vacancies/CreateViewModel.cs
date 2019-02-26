using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using testTask.Enums;

namespace testTask.Models.Vacancies
{
    public class CreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public WorkingConditions WorkingCondition { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public bool IsRemoteWorking { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CompanyURL { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ContactPartner { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public CurrencyTypes CurrencyType { get; set; }
    }
}
