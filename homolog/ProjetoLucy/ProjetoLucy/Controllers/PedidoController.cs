using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLucy.Controllers
{
    public class PedidoController : Controller
    {
		protected PedidoRepository _pedidoRepository;

		public PedidoController()
		{
			_pedidoRepository = new PedidoRepository();
		}
		// GET: Pedido
		public ActionResult Pedido()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Pedido(Pedido obj)
		{
			if (obj.PedidoId > 0)
			{
				_pedidoRepository.Add(obj);
			}
			else
			{
				_pedidoRepository.Update(obj);
			}
			return View("Listar");
		}

		public ActionResult Listar()
		{
			var lista = _pedidoRepository.GetAll();

			return View(lista);
		}

	}
}