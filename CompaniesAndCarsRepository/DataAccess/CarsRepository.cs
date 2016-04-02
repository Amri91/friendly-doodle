using CompaniesAndCars.DataAccess;
using CompaniesAndCars.Models;
using LightADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CompaniesAndCars.DataAccess
{
    public class CarsRepository : Repository<Car>
    {
        // To eleminate magic strings
        public override string InsertProc { get { return "uspInsertCar"; } }
        public override string UpdateProc { get { return "uspUpdateCar"; } }
        public override string RetrieveProc { get { return "uspGetCars"; } }
        public string DeleteProc { get { return "uspDeleteCar"; } }

        public override Car Get(int id)
        {
            return new Query().ExecuteToObject<Car>(RetrieveProc, CommandType.StoredProcedure, new Parameter(nameof(Car.CarId), id));
        }
        public override Boolean Delete(int id)
        {
            return new NonQuery().Execute(DeleteProc, CommandType.StoredProcedure, new Parameter(nameof(Car.CarId), id));
        }
    }
}