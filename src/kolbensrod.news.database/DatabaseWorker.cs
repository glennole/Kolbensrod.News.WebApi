using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace kolbensrod.news.database
{
    public class DatabaseWorker
    {
        public static int Migrate(string connectionString)
        {
            EnsureDatabase.For.PostgresqlDatabase(connectionString);
            
            var upgrader =
                DeployChanges.To
                    .PostgresqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();
          
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Console.ReadLine();
                return -1;
            }
            else
            {
                foreach (var resultScript in result.Scripts)
                {
                    Console.WriteLine($"Successfully added {resultScript.Name}.");
                }
                Console.WriteLine($"News was successfully upgraded with {result.Scripts.Count()} migration scripts.");
            }
            return 0;
        }
    }
}