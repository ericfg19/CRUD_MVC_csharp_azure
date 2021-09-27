using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_todolist.Models
{
    public class ListaModel
    {
        
        public Guid Id { get; set; }

        
        public string NomeTarefa { get; set; }

        
        public DateTime DataTarefa { get; set; }

        
        public string Detalhes { get; set; }

        
        public string Status { get; set; }

        
        public string Responsavel { get; set; }

  
    }
}
