using BookLib.Domain;
using BookLib.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookLibFunc.Microservice
{
    internal static class Bootstrap
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            DependencyResolver.Resolve(services);
            return services.BuildServiceProvider();
        }
    }
}
