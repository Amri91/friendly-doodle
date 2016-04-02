using CompaniesAndCars.DataAccess;
using CompaniesAndCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.OutputCache.V2;

namespace CompaniesAndCars.Controllers
{
    public class CarsController : ApiController
    {
        // The size of project does not justify using extra layers
        private Repository<Car> _carsRepository = new CarsRepository();

        // GET: api/Cars
        [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
        public IQueryable<Car> GetCars()
        {
            return _carsRepository.Get();
        }

        // GET: api/Cars/1
        [ResponseType(typeof(Car))]        
        public IHttpActionResult GetCar(int id)
        {
            Car car = _carsRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        [ArgumentNotNull]
        [ValidArgument]
        public IHttpActionResult PostItem(Car car)
        {
            car = _carsRepository.Insert(car);
            return CreatedAtRoute("DefaultApi", new { id = car.CarId }, car);
        }

        // DELETE: api/Car/1
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCar(int id)
        {
            if (!_itemExists(id))
            {
                return NotFound();
            }
            _carsRepository.Delete(id);
            return Ok();
        }

        // PUT: api/companies/1
        [ResponseType(typeof(void))]
        [ArgumentNotNull]
        [ValidArgument]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!_itemExists(id))
            {
                return NotFound();
            }
            _carsRepository.Update(car);
            return StatusCode(HttpStatusCode.NoContent);
        }

        private Boolean _itemExists(int id)
        {
            return _carsRepository.Get(id) != null;
        }
    }
}
