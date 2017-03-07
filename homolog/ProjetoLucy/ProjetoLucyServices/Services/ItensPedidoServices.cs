using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucyServices.Services
{
    public class ItensPedidoServices : IDisposable
    {

		protected ItensPedidoRepository _itensPedidoRepository;

		public ItensPedidoServices()
		{
			_itensPedidoRepository = new ItensPedidoRepository();
		}

		public ItensPedido Add(ItensPedido obj)
		{
			return _itensPedidoRepository.Add(obj);
		}

		public ItensPedido Update(ItensPedido obj)
		{
			return _itensPedidoRepository.Update(obj);
		}

		public IEnumerable<ItensPedido> GetAll()
		{
			return _itensPedidoRepository.GetAll();
		}

		public ItensPedido GetById(int itensPedidoId)
		{
			return _itensPedidoRepository.GetById(itensPedidoId);
		}

		public void Dispose()
        {
			_itensPedidoRepository.Dispose();
        }
    }
}
