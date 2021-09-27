using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class ListaTarefas
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "nometarefa")]
        public string NomeTarefa { get; set; }

        [JsonProperty(PropertyName = "datatarefa")]
        public DateTime DataTarefa { get; set; }

        [JsonProperty(PropertyName = "detalhes")]
        public string Detalhes { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "responsavel")]
        public string Responsavel { get; set; }

        [JsonProperty(PropertyName = "pk")]
        public string PartitionKey { get; set; } = "tarefasID";



    }
}
