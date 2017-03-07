using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Domain.Entities
{
    [Table("ProjetoLucy_Pedido")]
    public class Pedido
    {
        public int PedidoId { get; set; }
        [Display(Name = "Data do Pedido")]
        public DateTime Data_Pedido { get; set; }
        [Display(Name = "Forma de pagamento")]
        public string Forma_pg { get; set; }
        [Display(Name = "Total")]
        public double Total { get; set; }
    }
}
