using Dal.Interface;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using StructureMap;
using System;
using System.Collections.Generic;
using Dal.Implementation;
using StructureMap.Pipeline;

namespace Services.Tests
{
    class ServiceTestRegistry : Registry
    {

        public ServiceTestRegistry()
        {
            For<IUserService>().LifecycleIs(Lifecycles.Container)
                .Use<UserService>();
        }

    }
}
