using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using ProjetoLucyServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLucy.Controllers
{
    public class ItensPedidoController : Controller
    {
		//protected ItensPedidoRepository _itensPedidoServices;
		protected ItensPedidoServices _itensPedidoServices;

		public ItensPedidoController()
		{
			//_itensPedidoServices = new ItensPedidoRepository();
			_itensPedidoServices = new ItensPedidoServices();
		}
        // GET: ItensPedido
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(ItensPedido obj)
		{
			if (obj.ItensPedidoId > 0)
			{
				_itensPedidoServices.Update(obj);
			}
			else
			{
				_itensPedidoServices.Add(obj);
			}
			return View();
		}

		public ActionResult Listar(ItensPedido obj)
		{
			var lista = _itensPedidoServices.GetAll();

			return View(lista);
		}


    }
}