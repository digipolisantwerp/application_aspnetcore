using System;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace Digipolis.ApplicationServices.UnitTests.Context
{
    public class ApplicationContextCtorTests
    {
        [Fact]
        void ApplicationIdNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ApplicationContext(null, "appname"));
            Assert.Equal("applicationId", ex.ParamName);
            Assert.Contains("applicationId can not be null.", ex.Message);
        }

        [Fact]
        void ApplicationIdEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ApplicationContext("", "appname"));
            Assert.Equal("applicationId", ex.ParamName);
            Assert.Contains("applicationId can not be empty.", ex.Message);
        }

        [Fact]
        void ApplicationIdWhiteSpaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ApplicationContext("   ", "appname"));
            Assert.Equal("applicationId", ex.ParamName);
            Assert.Contains("applicationId can not be empty.", ex.Message);
        }

        [Fact]
        void ApplicationNameNullRaisesArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new ApplicationContext("123", null));
            Assert.Equal("applicationName", ex.ParamName);
            Assert.Contains("applicationName can not be null.", ex.Message);
        }

        [Fact]
        void ApplicationNameEmptyRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ApplicationContext("123", ""));
            Assert.Equal("applicationName", ex.ParamName);
            Assert.Contains("applicationName can not be empty.", ex.Message);
        }

        [Fact]
        void ApplicationNameWhiteSpaceRaisesArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ApplicationContext("123", "   "));
            Assert.Equal("applicationName", ex.ParamName);
            Assert.Contains("applicationName can not be empty.", ex.Message);
        }

        [Fact]
        void ApplicationVersionIsReturned()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.Equal(PlatformServices.Default.Application.ApplicationVersion, appContext.ApplicationVersion);
        }

        [Fact]
        void InternalApplicationNameIsReturned()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.Equal(PlatformServices.Default.Application.ApplicationName, appContext.InternalApplicationName);
        }

        [Fact]
        void InstanceIdIsInitialized()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.NotNull(appContext.InstanceId);
        }

        [Fact]
        void InstanceNameContainsInstanceId()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.Contains(appContext.InstanceName, appContext.InstanceName);
        }

        [Fact]
        void InstanceNameContainsMachineName()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.Contains(Environment.MachineName, appContext.InstanceName);
        }

        [Fact]
        void InstanceNameContainsApplicationName()
        {
            var appContext = new ApplicationContext("123", "myApp");
            Assert.Contains(appContext.ApplicationName, appContext.InstanceName);
        }
    }
}
