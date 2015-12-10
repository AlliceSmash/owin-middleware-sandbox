using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Configuration;
using Simple.Data;
using testkatana.Models;

namespace testkatana.Controllers
{
    public class CompaniesController : ApiController
    {

        public IEnumerable<Company> GetCompanies()
        {
            var connStr = ConfigurationManager.ConnectionStrings["katana-db"].ConnectionString;
            var db = Database.OpenConnection(connStr);

            IEnumerable<Company> companies = db.Company.All();
            return companies;
        }

        public Company   Get(int id)
        {
            var connStr = ConfigurationManager.ConnectionStrings["katana-db"].ConnectionString;
            var db = Database.OpenConnection(connStr);

             Company company =  db.Company.FindAllById(id).FirstOrDefault();
            return company;
        }
    }
}
