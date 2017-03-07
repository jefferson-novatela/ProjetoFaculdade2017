using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucyServices.Services
{
    public class ProdutoSevices : IDisposable
    {
        protected ProdutoRepository _produtoRepository;

        public ProdutoSevices()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public Produto Add(Produto obj)
        {
            return _produtoRepository.Add(obj);
        }

        public Produto Update(Produto obj)
        {
            return _produtoRepository.Update(obj);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

		public Produto GetById(int produtoId)
		{
			return _produtoRepository.GetById(produtoId);
		}

        public void Dispose()
        {
			_produtoRepository.Dispose();
        }
    }
}
