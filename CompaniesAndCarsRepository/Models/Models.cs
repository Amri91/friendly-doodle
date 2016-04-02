using CompaniesAndCars.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompaniesAndCars.Models
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        [Required]
        public string CarName { get; set; }
        // Foreign key
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }

    public class Company : IEntity
    {
        public Company() { }
        // Issue: Framework molding code
        public Company(int id)
        {
            Repository<Company> cRep = new CompaniesRepository();

            Company company = cRep.Get(id);
            if (company != null)
            {
                CompanyId = company.CompanyId;
                CompanyName = company.CompanyName;
            }
        }
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }

    public interface IEntity
    { }
}