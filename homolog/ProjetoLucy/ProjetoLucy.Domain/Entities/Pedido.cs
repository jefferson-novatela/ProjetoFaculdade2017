﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Domain.Entities
{
    [Table("ProjetoRay_Pedido")]
    public class Pedido
    {
		[Display(Name = "Número do pedido")]
		public int PedidoId { get; set; }		
		//public string NumeroPedido { get; set; }
		//[Display(Name = "Descrição do Pedido")]
		//public string DescricaoPed { get; set; }
		[Display(Name = "Data do Pedido")]
        public DateTime Data_Pedido { get; set; }
		[Display(Name = "Quantidade")]
		public string Qtd { get; set; }
		[Display(Name = "Valor do Produto")]
		//public string ValorProd { get; set; }
		//[Display(Name = "Forma de pagamento")]
        public string Forma_pg { get; set; }
        [Display(Name = "Total")]
        public double Total { get; set; }
		
	}
}
