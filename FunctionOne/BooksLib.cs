using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BookLib.Domain.Services;

namespace BookLibFunc.Microservice
{
    public static class BooksLib
    {
        [FunctionName("BooksLib")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
        {
            var serviceProvider = Bootstrap.ConfigureServices();
            log.LogInformation("Request a book based on ISBN13");

            string isbn = req.Query["isbn"];

            if (isbn == null)
                return new BadRequestObjectResult("Please pass ISBN number on the query string.");

            var book = serviceProvider.GetService<IBookSearchService>().SearchIsbn(isbn);
            return new OkObjectResult(book) as ActionResult;
        }
    }
}
