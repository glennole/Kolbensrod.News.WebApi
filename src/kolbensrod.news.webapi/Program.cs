using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kolbensrod.news.database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace kolbensrod.news.webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Create database
            //var connectionString = "Server=172.17.0.2;Port=5432;Database=News;User Id=postgres;Password=test;";
            //DatabaseWorker.Migrate(connectionString);   
            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls("http://127.0.0.1:5021")
                .Build();
    }
}
