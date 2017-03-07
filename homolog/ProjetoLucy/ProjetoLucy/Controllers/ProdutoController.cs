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
        public ActionResult Produto()
        {
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
                _produtoSevices.Add(obj);

				return RedirectToAction("Listar");
            }

            return View();
        }

		public ActionResult Listar()
		{
		   var lista =	_produtoSevices.GetAll();

			return View(lista);
		}
    }
}