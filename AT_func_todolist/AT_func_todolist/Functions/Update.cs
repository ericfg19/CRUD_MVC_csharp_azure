using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository.Database;
using Repository.Models;

namespace AT_func_todolist.Functions
{
    public static class Update
    {
        [FunctionName("Update")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ListaTarefas dataToUpdate = JsonConvert.DeserializeObject<ListaTarefas>(requestBody);

            var repository = new ListaTarefasDB();

            await repository.Update(dataToUpdate);

            return new OkObjectResult(dataToUpdate);
        }
    }
}
