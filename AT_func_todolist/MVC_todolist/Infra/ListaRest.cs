using MVC_todolist.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_todolist.Infra
{
    public class ListaRest
    {
        private string URL_TODOLIST_REST = "https://atfunctodolist202109.azurewebsites.net";

        public IList<ListaModel> GetAll()
        {
            var client = new RestClient(URL_TODOLIST_REST);

            var request = new RestRequest("api/GetAll", DataFormat.Json);

            var response = client.Get<IList<ListaModel>>(request);

            return response.Data;
        }

        public ListaModel GetById(Guid id)
        {
            var client = new RestClient(URL_TODOLIST_REST);

            var request = new RestRequest($"api/GetById?id={id}", DataFormat.Json);

            var response = client.Get<ListaModel>(request);

            return response.Data;
        }

        public void Save(ListaModel model)
        {
            var client = new RestClient(URL_TODOLIST_REST);

            var request = new RestRequest($"api/Save", Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(model);

            var response = client.Post<ListaModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("Não consegui criar a tarefa.");

        }

        public void Delete(Guid id)
        {
            var client = new RestClient(URL_TODOLIST_REST);

            var request = new RestRequest($"api/Delete?id={id}", DataFormat.Json);

            var response = client.Delete(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui deletar a tarefa.");
            
        }

        public void Update(ListaModel model)
        {
            var client = new RestClient(URL_TODOLIST_REST);

            var request = new RestRequest($"api/Update", DataFormat.Json);

            request.AddJsonBody(model);

            var response = client.Put<ListaModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui alterar a tarefa.");

        }
    }
}
