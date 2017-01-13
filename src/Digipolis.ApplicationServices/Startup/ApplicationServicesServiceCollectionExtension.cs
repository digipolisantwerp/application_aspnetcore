using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Digipolis.ApplicationServices
{
    public static class ApplicationServicesServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, Action<ApplicationServicesOptions> setupAction)
        {
            services.Configure(setupAction);

            var options = GetOptions(setupAction);

            var appContext = new ApplicationContext(options.ApplicationId, options.ApplicationName);
            services.AddSingleton<IApplicationContext>(appContext);

            return services;
        }

        private static ApplicationServicesOptions GetOptions(Action<ApplicationServicesOptions> setupAction)
        {
            var options = new ApplicationServicesOptions();
            setupAction.Invoke(options);

            if ( options.ApplicationId == null ) throw new ArgumentNullException("ApplicationId", "ApplicationId can not be null.");
            if ( options.ApplicationId.Trim() == String.Empty ) throw new ArgumentException("ApplicationId cannot be empty.", "ApplicationId");
            if ( String.IsNullOrWhiteSpace(options.ApplicationName) ) options.ApplicationName = PlatformServices.Default.Application.ApplicationName;

            return options;
        }
    }
}
