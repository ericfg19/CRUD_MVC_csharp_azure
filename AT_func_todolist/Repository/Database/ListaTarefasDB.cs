using Microsoft.Azure.Cosmos;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class ListaTarefasDB
    {
        private const string ConnectionString = "AccountEndpoint=https://todolistinfnet.documents.azure.com:443/;AccountKey=E0WOUhvKWaIpq4ZUBrxNOPLVLPL9nmvcQZ9GiKW6nMxpmXvWk4bQSzhYQEGTentnkDzsrQl5iAd5t2UmWSQqDw==;";
        private const string Database = "todolistID"; // o correto sera pra ser "todolistDB" mas foi cadastrado "todolistID"
        private const string Container = "tarefasID";


        private CosmosClient CosmosClient { get; set; }

        public ListaTarefasDB()
        {
            this.CosmosClient = new CosmosClient(ConnectionString);
        }




        public List<ListaTarefas> GetAll()
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition("SELECT * FROM c");

            var resultado = new List<ListaTarefas>();

            var queryResult = container.GetItemQueryIterator<ListaTarefas>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<ListaTarefas> currentResultSet = queryResult.ReadNextAsync().Result;
                resultado.AddRange(currentResultSet.Resource);
            }


            return resultado;
        }

        public ListaTarefas GetById(Guid id)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c where c.id = '{id}'");

            var result = new List<ListaTarefas>();

            var queryResult = container.GetItemQueryIterator<ListaTarefas>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<ListaTarefas> currentResultSet = queryResult.ReadNextAsync().Result;
                result.AddRange(currentResultSet.Resource);
            }

            return result.FirstOrDefault();
        }
        public async Task Save(ListaTarefas obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.CreateItemAsync<ListaTarefas>(obj, new PartitionKey(obj.PartitionKey));
        }
        public async Task Delete(ListaTarefas obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.DeleteItemAsync<ListaTarefas>(obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }
        public async Task Update(ListaTarefas obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.ReplaceItemAsync<ListaTarefas>(obj, obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }
    }
}
