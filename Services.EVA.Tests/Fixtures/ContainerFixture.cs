using AutoMapper;
using StructureMap;
using System;

namespace Services.Tests.Fixtures
{
    public class ContainerFixture : IDisposable
    {
      //  private const EndpointNames Endpoint = EndpointNames.EvaPortal;
        public static object thisLock = new object();
        private static bool _initialized = false;

        public IContainer Container { get; private set; }
        public ContainerFixture()
        {
            Container = new Container();
            Container.Configure(config =>
            {
                config.AddRegistry(new ServiceTestRegistry());
            });
            lock (thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(config =>
                    {
                        //config;
                        // .AddEndpointMappings()
                        //.AddServiceMappings(Endpoint);
                    });
                    _initialized = true;
                }
            }
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
