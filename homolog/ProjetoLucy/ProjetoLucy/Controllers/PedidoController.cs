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
		private readonly List<SelectListItem> _formPag = new List<SelectListItem> {

			new SelectListItem { Text = "Dinheiro" , Value = "Dinheiro"},
			new SelectListItem { Text = "Crédito" , Value = "Credito"}

		};
		public PedidoController()
		{
			_pedidoRepository = new PedidoRepository();
		}
		// GET: Pedido
		public ActionResult Pedido()
        {
			var lista = _pedidoRepository.GetAll();
			ViewBag.Pedido = lista;

			return View(new Pedido());
        }

		[HttpPost]
		public ActionResult Pedido(Pedido obj)
		{
			if (obj.PedidoId > 0)
			{				
				_pedidoRepository.Update(obj);
			}
			else
			{
				_pedidoRepository.Add(obj);
			}

			var lista = _pedidoRepository.GetAll();
			ViewBag.Pedido = lista;
			return View("Listar");
		}

		public ActionResult Listar()
		{
			var lista = _pedidoRepository.GetAll();

			return View(lista);
		}

	}
}