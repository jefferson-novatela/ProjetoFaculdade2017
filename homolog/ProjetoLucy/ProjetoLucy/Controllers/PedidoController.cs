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
    public class PedidoController : Controller
    {
		protected PedidoServices _pedidoService;
		protected ProdutoSevices _produtoService;

		//private readonly List<SelectListItem> _formPag = new List<SelectListItem> {

		//	new SelectListItem { Text = "Dinheiro" , Value = "Dinheiro"},
		//	new SelectListItem { Text = "Crédito" , Value = "Credito"},
		//	new SelectListItem { Text = "Débito", Value = "Debito"}

		//};

		public PedidoController()
		{
			_pedidoService = new PedidoServices();
			_produtoService = new ProdutoSevices();
		}
		
		public ActionResult Pedido()
        {			
			
			var lista = _produtoService.GetAll();
			ViewBag.Pedido = lista;

			return View(new Pedido());
        }

		[HttpPost]
		public ActionResult Pedido(Pedido obj, Produto prod)
		{
			if (obj.PedidoId > 0)
			{				
				_pedidoService.Update(obj);
			}
			else
			{
				ItensPedido itensPedido = new ItensPedido();
				

				obj.Data_Pedido = DateTime.Now;
				_pedidoService.Add(obj);
				//itensPedido.PedidoId = obj.PedidoId;
				
			}

			var lista = _pedidoService.GetAll();
			ViewBag.Pedido = lista;
			return RedirectToAction("Listar");
		}

		public ActionResult Listar()
		{
			var lista = _pedidoService.GetAll();

			return View(lista);
		}

	}
}