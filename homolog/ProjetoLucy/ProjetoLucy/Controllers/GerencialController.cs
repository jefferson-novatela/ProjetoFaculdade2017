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
		protected UsuarioRepository _usuarioRepository;
		protected UsuarioServices _usuarioServices;
		public GerencialController()
		{
			_usuarioRepository = new UsuarioRepository();
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
				if (usr != null)
				{
					CriarCookie(usr);
					_usuarioServices.Dispose();
					return RedirectToAction("Index", "Home", new { Controller = "Gerencial" });
				}
			}

			
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