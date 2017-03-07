using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Domain.Entities
{
    [Table("ProjetoLucy_Produto")]
    public class Produto
    {      
        public int ProdutoId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Total")]
        public double Total { get; set; }
    }
}
