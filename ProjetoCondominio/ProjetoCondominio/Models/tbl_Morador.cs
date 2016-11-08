namespace ProjetoCondominio.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Morador
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Nome_Morador { get; set; }

        [StringLength(10)]
        public string CPF { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Telefone { get; set; }

        public int? Id_Casa { get; set; }

        public virtual tbl_Casa tbl_Casa { get; set; }
    }
}
