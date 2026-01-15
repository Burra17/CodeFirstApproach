using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace CodeFirstApproach.Database
{
    public class InstagramDatabaseFactory : IDesignTimeDbContextFactory<InstagramDatabase>
    {
        public InstagramDatabase CreateDbContext(string[] args)
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
