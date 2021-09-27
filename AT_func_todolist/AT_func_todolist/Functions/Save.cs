using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository.Models;
using Repository.Database;


namespace AT_func_todolist.Functions
{
    public static class Save
    {
        [FunctionName("Save")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ListaTarefas data = JsonConvert.DeserializeObject<ListaTarefas>(requestBody);
            data.Id = Guid.NewGuid();

            var repository = new ListaTarefasDB();

            await repository.Save(data);

            return new CreatedResult($"", data);

            
        }
    }
}
