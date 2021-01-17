using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace ContactManagement.IntegrationTest.API
{
    /// <summary>
    /// This class marks that is a test class 
    /// </summary>
    public class TestFixture<TStartup>
        : IDisposable
    {

        readonly IWebHost _webHost;

        public IServiceProvider ServiceProvider { get; }

        public TestFixture()
        {
            _webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup(typeof(TStartup))
                .Build();

            ServiceProvider = _webHost.Services;
        }

        public void Dispose()
        {
            _webHost?.Dispose();
        }

    }
}