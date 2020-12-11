using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bertoni.Examen.Application
{
    public static class DIApplication
    {
        public static void AddServicesApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DIApplication));
        }
    }
}
