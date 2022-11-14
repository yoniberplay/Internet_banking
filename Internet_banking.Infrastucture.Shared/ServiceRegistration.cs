using Internet_banking.Infrastucture.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Internet_banking.Core.Domain.Settings;
using Internet_banking.Core.Application.Interfaces.Services;

namespace Internet_banking.Infrastucture.Shared.Services
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddShareInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
