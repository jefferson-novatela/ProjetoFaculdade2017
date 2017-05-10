using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Infra.Repository
{
	public class UsuarioRepository : RepositoryBase<Usuario>
	{

		public Usuario GetUsuario(Usuario usr)
		{
			try
			{
				return Db.Usuarios.FirstOrDefault(s => s.Email == usr.Email && s.Senha == usr.Senha);
			}
			catch (Exception e)
			{
				throw;
			}
			
		}

		public bool UsuarioExistente(string email)
		{
			var usuario = Db.Usuarios.FirstOrDefault(u => u.Email == email && !u.Removido);
			return usuario != null;
		}
	}
}
