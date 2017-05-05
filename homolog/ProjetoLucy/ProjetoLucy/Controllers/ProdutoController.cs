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
    public class ProdutoController : Controller
    {
        protected ProdutoRepository _produtoRepository;
		protected ProdutoSevices _produtoSevices;

		public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
			_produtoSevices = new ProdutoSevices();
        }

        // GET: Produto
        public ActionResult Produto(int id = 0)
        {			
			var lista = _produtoSevices.GetAll().Where(s => s.RemoveProduto != true);
			ViewBag.lista = lista;
			if (id > 0)
			{
				var editar = _produtoSevices.GetById(id);
				return View(editar);
			}
			
			return View(new Produto());
        }		

		[HttpPost]
        public ActionResult Produto(Produto obj)
        {
			
            if(obj.ProdutoId > 0)
            {
               _produtoSevices.Update(obj);
            }
			else
            {				
				obj.CodProduto = obj.GerarCodigoProduto();
                _produtoSevices.Add(obj);				
            }
			var lista = _produtoSevices.GetAll();
			ViewBag.lista = lista;
			return RedirectToAction("Listar");
        }

		public ActionResult Listar()
		{
		   var lista =	_produtoSevices.GetAll().Where(s => s.RemoveProduto != true);

			return View(lista);
		}

		public ActionResult RemoverProduto(int id)
		{
			var produto = _produtoSevices.GetById(id);
			produto.RemoveProduto = !produto.RemoveProduto;
			_produtoSevices.Update(produto);
			return RedirectToAction("Produto");
		}

		public ActionResult RemoverProdutosLista(int id)
		{
			var produto = _produtoSevices.GetById(id);
			produto.RemoveProduto = !produto.RemoveProduto;
			_produtoSevices.Update(produto);
			return RedirectToAction("Listar");
		}

		public ActionResult Editar(int id)
		{
			var editar = _produtoSevices.GetById(id);

			return View();
		}
		
	}
}