using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence
{
    public class SolutionDbContextFactory : IDesignTimeDbContextFactory<SolutionDbContext>
    {
        public SolutionDbContext CreateDbContext (string[] args)
        {
            var projectPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../Solution.API"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SolutionDbContext>();
            var connectionString = configuration.GetConnectionString("SolutionConnectionString");
            builder.UseSqlServer(connectionString);

            return new SolutionDbContext(builder.Options);
        }
    }
}