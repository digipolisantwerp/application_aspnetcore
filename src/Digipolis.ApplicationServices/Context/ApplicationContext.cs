using System;
using Microsoft.Extensions.PlatformAbstractions;

namespace Digipolis.ApplicationServices
{
    public class ApplicationContext : IApplicationContext
    {
        public ApplicationContext(string applicationId, string applicationName)
        {
            ValidateRequiredArguments(applicationId, applicationName);

            ApplicationId = applicationId;
            ApplicationName = applicationName;
            InstanceId = Guid.NewGuid().ToString();
            InstanceName = $"{Environment.MachineName}_{ApplicationName}_{InstanceId}";
        }

        public string ApplicationId { get; private set; }

        public string ApplicationName { get; private set; }

        public string InstanceId { get; private set; }

        public string InstanceName { get; private set; }

        public string InternalApplicationName => PlatformServices.Default.Application.ApplicationName;

        public string ApplicationVersion => PlatformServices.Default.Application.ApplicationVersion;

        private void ValidateRequiredArguments(string applicationId, string applicationName)
        {
            if ( applicationId == null ) throw new ArgumentNullException(nameof(applicationId), $"{nameof(applicationId)} can not be null.");
            if ( applicationName == null ) throw new ArgumentNullException(nameof(applicationName), $"{nameof(applicationName)} can not be null.");
            if ( applicationId.Trim() == String.Empty ) throw new ArgumentException($"{nameof(applicationId)} can not be empty.", nameof(applicationId));
            if ( applicationName.Trim() == String.Empty ) throw new ArgumentException($"{nameof(applicationName)} can not be empty.", nameof(applicationName));
        }
    }
}
