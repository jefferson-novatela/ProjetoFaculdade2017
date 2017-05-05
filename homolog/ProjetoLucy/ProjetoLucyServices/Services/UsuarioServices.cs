using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucyServices.Services
{
    public class UsuarioServices : IDisposable
    {
		protected UsuarioRepository _usuarioRepository;

		public UsuarioServices()
		{
			_usuarioRepository = new UsuarioRepository();
		}

		public Usuario Add(Usuario obj)
		{
			return _usuarioRepository.Add(obj);
		}

		public Usuario Update(Usuario obj)
		{
			return _usuarioRepository.Update(obj);
		}

		public Usuario GetUsuario(Usuario usr)
		{
			return _usuarioRepository.GetUsuario(usr);
		}

		public bool UsuarioExistente(string email)
		{
			return _usuarioRepository.UsuarioExistente(email);
		}

		public void Dispose()
        {
			_usuarioRepository.Dispose();
        }
    }
}
