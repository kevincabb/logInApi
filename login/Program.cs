using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using login.Services;
using login.Models;

namespace login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Creating an instance of DataService so its accessible in static void Main
            var dservice = new DataService();

            //Retrieve the fixedData information
            var allCreds = dservice.GetCredentials();

            //User sets up your Query(C#) -----> LINQ -----> SQL(DataSource) or other data sources
            //SQL -----> LINQ ------> Sends back a collection to user

            //Setting up your linq Query
            //This Query returns a new collection into myLinqQuery

            //Where statement
            var myLinqQuery = from t in allCreds
                              where t.userName.Contains("k")
                              select t;

            //Looping through the new collection from Query
            foreach(credentials cred in myLinqQuery)
            {
                System.Console.WriteLine("Credential Name: " + cred.userName);
            }

            
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
