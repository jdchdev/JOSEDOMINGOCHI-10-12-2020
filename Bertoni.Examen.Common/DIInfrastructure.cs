using Bertoni_Examen.Infrastructure.NetWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;

namespace Bertoni_Examen.Infrastructure
{
    public static class DIInfrastructure
    {
        public static void AddServicesInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<IClientWrapper, ClientWrapper>();
        }
    }
}
