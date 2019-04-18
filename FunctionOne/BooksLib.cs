using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BookLib.Domain.Services;
using System;

namespace BookLibFunc.Microservice
{
    public static class BooksLib
    {
        private static IServiceProvider _serviceProvider;

        static BooksLib()
        {
            _serviceProvider = Bootstrap.ConfigureServices();
        }

        [FunctionName("Books")]
        public static IActionResult Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Books({isbn})")]HttpRequest req, 
            ILogger log, string isbn)
        {
            log.LogInformation("Request a book based on ISBN13");

            if (isbn == null)
                return new BadRequestObjectResult("Please pass ISBN number on the query string.");

            var book = _serviceProvider.GetService<IBookSearchService>().SearchIsbn(isbn);
            return new OkObjectResult(book) as ActionResult;
        }
    }
}
