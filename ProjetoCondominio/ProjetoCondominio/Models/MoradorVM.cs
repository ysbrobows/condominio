using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCondominio.Models
{
    public class MoradorVM
    {
        public string ID { get; set; }
        public string Nome_Morador { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Id_Casa { get; set; }
        public string Casa { get; set; }
        public string Rua { get; set; } 
        public string Id_Rua { get; set; }
    }
}