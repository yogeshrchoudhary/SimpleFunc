using Microsoft.Azure.WebJobs;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

[assembly: Microsoft.Azure.WebJobs.Hosting.WebJobsStartup(typeof(BookLibFunc.Microservice.Bootstrap))]
namespace BookLibFunc.Microservice
{
    internal class Bootstrap : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddDependencyInjection((services) => {
                BookLib.Domain.DependencyResolver.Resolve(services);
            });
        }
    }
}
