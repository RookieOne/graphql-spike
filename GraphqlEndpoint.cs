using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GraphQL.Types;
using GraphQL;
using GraphQL.SystemTextJson;
// using System;
// using System.Threading.Tasks;
// using GraphQL;
// using GraphQL.Types;
// using GraphQL.SystemTextJson;

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

            var schema = Schema.For(@"
            type Query {
                hello: String
                message: String
            }
            ");

            var root = new
            {
                Hello = "Hello World!",
                Message = "May the force be with you"
            };

            Console.WriteLine(req.Body.ToString());

            var query = await new StreamReader(req.Body).ReadToEndAsync();

            Console.WriteLine(query);

            var json = await schema.ExecuteAsync(_ =>
            {
                // _.Query = "{ hello }";
                _.Query = query;
                // _.Query = req.Body.ToString();
                _.Root = root;
            });

            Console.WriteLine(json);

            return new OkObjectResult(json);
        }
    }
}
