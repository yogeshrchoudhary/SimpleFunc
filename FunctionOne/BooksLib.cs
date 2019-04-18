//Using DI as mentioned in the blog https://blog.wille-zone.de/post/dependency-injection-for-azure-functions/ but without Autofac (i.e. using Microsoft.Extensions.DependencyInjection)

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BookLib.Domain.Services;
using System.Threading.Tasks;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

namespace BookLibFunc.Microservice
{
    public class BooksLib
    {
        private IBookSearchService _bookSearchService;

        //CTOR INJECTION DOESN'T WORK YET!! SO STICK TO FUNCTION INJECTION UNTIL THEN
        //public BooksLib([Inject] IBookSearchService bookSearchService)
        //{
        //    _bookSearchService = bookSearchService;
        //}

        [FunctionName("Books")]
        public async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Books({isbn})")] HttpRequest req,
            [Inject] IBookSearchService bookSearchService,
            ILogger log,
            string isbn)
        {
            log.LogInformation("Request a book based on ISBN13");

            if (isbn == null)
                return new BadRequestObjectResult("Please pass ISBN number on the query string.");

            var book = await bookSearchService.SearchIsbn(isbn);
            return new OkObjectResult(book) as ActionResult;
        }
    }
}
