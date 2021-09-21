using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using GraphQL.Types;
using GraphQL;
using GraphQL.SystemTextJson;

namespace GraphqlSpike.Function
{
    public static class GraphqlEndpoint
    {
        [FunctionName("GraphqlEndpoint")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var schema = new Schema { Query = new Query() };

            var query = await new StreamReader(req.Body).ReadToEndAsync();

            var json = await schema.ExecuteAsync(_ =>
            {
                _.Query = query;
            });

            return new OkObjectResult(json);
        }
    }
}
