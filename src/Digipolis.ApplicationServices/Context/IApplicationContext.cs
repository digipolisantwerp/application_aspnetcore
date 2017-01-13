using System;

namespace Digipolis.ApplicationServices
{
    public interface IApplicationContext
    {
        string ApplicationId { get; }
        string ApplicationName { get; }
        string InstanceId { get; }
        string InstanceName { get; }
        string ApplicationVersion { get; }
        string InternalApplicationName { get; }
    }
}
