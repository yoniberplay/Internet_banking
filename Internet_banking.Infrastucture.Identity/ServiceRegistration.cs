using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internet_banking.Infrastucture.Identity.Context;
using Internet_banking.Infrastucture.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Internet_banking.Infrastructure.Identity
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                m=> m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            }
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            #endregion
        }
    }
}
