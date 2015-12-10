using System;
using System.Collections.Generic;
using System.Linq;

namespace OwinWebApiClient_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read all the companies...");
            var companyClient = new CompanyClient("http://localhost:8080");
            var companies = companyClient.GetCompanies();
            WriteCompaniesList(companies);

            var company = companyClient.GetCompany(1);
            WriteCompany(company);
            Console.ReadLine();
        }

        static void WriteCompany(Company company)
        {
            Console.WriteLine("Id: {0} Name: {1}", company.Id, company.Name);
        }

        static void WriteCompaniesList(IEnumerable<Company> companies)
        {
            companies.OrderBy(c => c.Id).ToList().ForEach(WriteCompany);
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
