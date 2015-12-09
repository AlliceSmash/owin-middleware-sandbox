using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace OwinSelfHostMinimalClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read all the companies...");
            var companyClient = new CompanyClient("http://localhost:8080");
            var companies = companyClient.GetCompanies();
            WriteCompaniesList(companies);

            int nextId = (from c in companies select c.Id).Max() + 1;

            Console.WriteLine("Add a new company...");
            var result = companyClient.AddCompany(
                new Company
                {
                    Id = nextId,
                    Name = string.Format("New Company #{0}", nextId)
                });
            WriteStatusCodeResult(result.StatusCode);

            Console.WriteLine("After adding a new company, here is the list of companies:");
            companies = companyClient.GetCompanies();
            WriteCompaniesList(companies);

             Console.WriteLine("The first company is: ");
            var company = companyClient.GetCompany(1);
            if (null != company) WriteCompany(company);

            Console.WriteLine("Updating that company:");
            company.Name = "New Microsoft";
            companyClient.Update(company);
            Console.WriteLine("The updated company is: ");
            WriteCompany(companyClient.GetCompany(1));

            Console.WriteLine("Deleting the last company:");
            var response = companyClient.DeleteCompany(nextId);
            WriteStatusCodeResult(response.StatusCode);

            Console.WriteLine("After all updates, the current list of companies is:");
            WriteCompaniesList(companyClient.GetCompanies());
            Console.Read();
        }

        static void WriteCompany(Company company)
        {
                Console.WriteLine("Id: {0} Name: {1}", company.Id, company.Name);
        }

        static void WriteCompaniesList(IEnumerable<Company> companies)
        {
            companies.ToList().ForEach(WriteCompany);
            Console.WriteLine("");
        }

        static void WriteStatusCodeResult(System.Net.HttpStatusCode statusCode)
        {
            if (statusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Opreation Succeeded - status code {0}", statusCode);
            }
            else
            {
                Console.WriteLine("Opreation Failed - status code {0}", statusCode);
            }
            Console.WriteLine("");
        }
    }
}
