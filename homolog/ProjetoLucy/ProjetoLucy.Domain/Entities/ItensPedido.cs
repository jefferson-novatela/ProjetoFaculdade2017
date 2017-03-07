using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Domain.Entities
{
    [Table("ProjetoLucy_ItensPedido")]
    public class ItensPedido
    {
        public int ItensPedidoId { get; set; }
        [Display(Name = "Pedidos")]
        [Required]
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
