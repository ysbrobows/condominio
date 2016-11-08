using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoCondominio.Models
{
    public class FuncionarioVM
    {
        public string ID { get; set; }
        public string Nome_Funcionario { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Id_Casa { get; set; }
        public string Casa { get; set; }
        public string Rua { get; set; }
        public string Id_Rua { get; set; }
    }
}
