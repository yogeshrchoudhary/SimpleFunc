using BookLib.Domain.Services;
using BookLib.Domain.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BookLib.Domain
{
    public static class DependencyResolver
    {
        public static void Resolve(ServiceCollection services)
        {
            services.AddTransient<IBookSearchService, BookSearchService>();
        }
    }
}
