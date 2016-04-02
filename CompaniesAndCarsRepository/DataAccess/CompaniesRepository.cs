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
    public class CompaniesRepository : Repository<Company>
    {
        // To eleminate magic strings
        public override string InsertProc { get { return "uspInsertCompany"; } }
        public override string UpdateProc { get { return "uspUpdateCompany"; } }
        public override string RetrieveProc { get { return "uspGetCompanies"; } }
        public string DeleteProc { get { return "uspDeleteCompany"; } }

        public override Company Get(int id)
        {
            return new Query().ExecuteToObject<Company>(RetrieveProc, CommandType.StoredProcedure, new Parameter(nameof(Company.CompanyId), id));
        }
        public override Boolean Delete(int id)
        {
            return new NonQuery().Execute(DeleteProc, CommandType.StoredProcedure, new Parameter(nameof(Company.CompanyId), id));
        }
    }
}