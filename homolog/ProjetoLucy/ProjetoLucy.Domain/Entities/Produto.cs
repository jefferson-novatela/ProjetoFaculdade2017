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
		[Display(Name = "Código do Produto")]		
		public string CodProduto { get; set; }
		[Display(Name = "Descrição")]
		[Required(ErrorMessage = "Descrição do Produto Obrigatoria!")]
		public string Descricao { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Valor Produto")]
		[Required(ErrorMessage = "Valor Produto Obrigatorio!")]
		public double VlrProduto { get; set; }
		[Display(Name = "Quantidade Estoque")]
		public double Quantidade { get; set; }
		public bool RemoveProduto { get; set; }

		public string GerarCodigoProduto()
		{
			string guild = Guid.NewGuid().ToString().Replace("-", "");
			Random random = new Random();
			const byte tamanhoCodigo = 8;

			string codProduto = "";

			for (int i = 0; i < tamanhoCodigo; i++)
			{
				codProduto += guild.ElementAt(random.Next(1, 9));
			}

			return codProduto;
		}
	}
}
