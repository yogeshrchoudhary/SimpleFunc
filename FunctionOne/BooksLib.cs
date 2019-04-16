
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace FunctionOne
{
    public static class BooksLib
    {
        [FunctionName("BooksLib")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Request a book based on ISBN13");

            string isbn = req.Query["isbn"];

            return isbn != null
                ? (ActionResult)new OkObjectResult($"Searching book with ISBN 13 = {isbn}...")
                : new BadRequestObjectResult("Please pass ISBN number on the query string.");
        }
    }
}
