namespace ProjetoCondominio.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Casa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Casa()
        {
            tbl_Funcionario = new HashSet<tbl_Funcionario>();
            tbl_Morador = new HashSet<tbl_Morador>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Casa { get; set; }

        public int Id_Rua { get; set; }

        public virtual tbl_Rua tbl_Rua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Funcionario> tbl_Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Morador> tbl_Morador { get; set; }
    }
}
