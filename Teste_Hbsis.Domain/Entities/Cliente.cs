namespace Teste_Hbsis.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string Documento { get; set; }

        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }

        public bool Excluido { get; set; }

        public bool IsCpf { get; set; }
    }
}
