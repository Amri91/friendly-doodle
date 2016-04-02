using CompaniesAndCars.Models;
using LightADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesAndCars.DataAccess
{
    public abstract class Repository<T> where T : IEntity
    {
        public abstract string InsertProc { get; }
        public abstract string UpdateProc { get; }
        public abstract string RetrieveProc { get; }

        public IQueryable<T> Get()
        {
            return new Query().ExecuteToListOfObject<T>(RetrieveProc, CommandType.StoredProcedure).AsQueryable();
        }
        public abstract T Get(int id);
        public T Insert(T obj)
        {
            if (new NonQuery().Execute(InsertProc, obj))
            {
                return obj;
            }
            return default(T);
        }
        public Boolean Update(T obj)
        {
            return new NonQuery().Execute(UpdateProc, obj);
        }
        public abstract Boolean Delete(int id);
    }
}
