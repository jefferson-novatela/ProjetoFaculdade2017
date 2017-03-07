using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Domain.Entities
{
    [Table("ProjetoLucy_Usuario")]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Cep")]
        public string Cep { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public int Senha { get; set; }
        public int ConfirmaSenha { get; set; }
        public String Email { get; set; }
    }
}
