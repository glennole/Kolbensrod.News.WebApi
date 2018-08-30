using System;

namespace kolbensrod.news.database
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=172.17.0.2;Port=5432;Database=News;User Id=postgres;Password=test;";
            DatabaseWorker.Migrate(connectionString);
        }
    }
}