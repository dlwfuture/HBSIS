using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Entities;

namespace Teste_Hbsis.Domain.Models
{
    [NotMapped]
    public class ClienteModel
    {
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
