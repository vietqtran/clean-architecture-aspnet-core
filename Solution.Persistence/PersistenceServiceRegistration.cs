using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Pesistence;
using Solution.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SolutionDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SolutionConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

            return services;
        }
    }
}
