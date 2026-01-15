using CodeFirstApproach.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace CodeFirstApproach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa instans av InstagramDatabase och använd den för databasoperationer
            using var db = CreateDbContext();

            // Hämta alla användare från databasen
            var users = db.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}");
            }
        }
        static InstagramDatabase CreateDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            var cs = config.GetConnectionString("InstagramDatabase");

            if (string.IsNullOrEmpty(cs))
            {
                throw new InvalidOperationException("Connection string 'InstagramDatabase' not found.");
            }

            var options = new DbContextOptionsBuilder<InstagramDatabase>()
                .UseSqlServer(cs)
                .Options;

            return new InstagramDatabase(options);
        }
    }
}
