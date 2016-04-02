using CompaniesAndCars.DataAccess;
using CompaniesAndCars.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CompaniesAndCars.Controllers
{
    public class CompaniesController : ApiController
    {
        // The size of project does not justify using extra layers
        private Repository<Company> _companiesRepository = new CompaniesRepository();

        // GET: api/Companies
        public IQueryable<Company> GetCompanies()
        {
            return _companiesRepository.Get();
        }

        // GET: api/Companies/1
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = _companiesRepository.Get(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        [ArgumentNotNull]
        [ValidArgument]
        public IHttpActionResult PostCompany(Company company)
        {
            company = _companiesRepository.Insert(company);            
            return CreatedAtRoute("DefaultApi", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Company/1
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCompany(int id)
        {
            if(!_itemExists(id))
            {
                return NotFound();
            }
            _companiesRepository.Delete(id);
            return Ok();
        }

        // PUT: api/companies/1
        [ResponseType(typeof(void))]
        [ArgumentNotNull]
        [ValidArgument]
        public IHttpActionResult PutItem(int id, Company company)
        {
            if (!_itemExists(id))                
            {
                return NotFound();
            }
            _companiesRepository.Update(company);
            return StatusCode(HttpStatusCode.NoContent);
        }

        private Boolean _itemExists(int id)
        {
            return _companiesRepository.Get(id) != null;
        }
    }
}
