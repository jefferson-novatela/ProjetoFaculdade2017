using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using ProjetoLucyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProjetoLucy.Controllers
{
    public class GerencialController : Controller
    {		
		protected UsuarioServices _usuarioServices;
		public GerencialController()
		{
			
			_usuarioServices = new UsuarioServices();
		}
        // GET: Gerencial
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(Usuario usr)
		{
			if (ModelState.IsValid)
			{
				usr = _usuarioServices.GetUsuario(usr);

				if (usr != null)
				{
					if (usr.Removido)
					{
						ModelState.AddModelError("UserNotFound", "Usuário bloqueado.");
						return View();
					}

					CriarCookie(usr);
					_usuarioServices.Dispose();
					return RedirectToAction("Index", "Home", new { Controller = "Gerencial" });
				}
			}

			ModelState.AddModelError("UserNotFound", "Usuario não encontrado!");
			return View();
		}

		public void CriarCookie(Usuario usr)
		{
			Cookies.SetCookie("UsuarioId", usr.UsuarioId.ToString());
			Cookies.SetCookie("UsuarioNome", usr.Nome);			
		}

		private void CreateTicket(Usuario usuario, IEnumerable<string> role)
		{
			var ticket = new FormsAuthenticationTicket(1, usuario.Nome, DateTime.Now, DateTime.Now.AddHours(5), false, string.Join("|", role));
			var encryptedTicket = FormsAuthentication.Encrypt(ticket);
			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

			Response.Cookies.Add(cookie);
		}

		[HttpPost]
		public ActionResult Cadastrar(Usuario cadastro)
		{
			if (_usuarioServices.UsuarioExistente(cadastro.Email))
			{
				ModelState.AddModelError("UserNotFound", "Este endereço de e-mail já está cadastrado no sistema.");
				return View("Login", cadastro);
			}

			if (cadastro.Senha != cadastro.ConfirmaSenha)
			{
				ModelState.AddModelError("UserNotFound", "As senhas são diferentes por favor digite as senhas iguais!");
			}
			else
			{
				_usuarioServices.Add(cadastro);
			}		
			return RedirectToAction("Login");
		}

		public ActionResult Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				Session.Abandon();
				FormsAuthentication.SignOut();
			}
			Cookies.RemoveAll();
			return RedirectToAction("Login", "Gerencial", new { area = "Controller" });
		}
	}
}