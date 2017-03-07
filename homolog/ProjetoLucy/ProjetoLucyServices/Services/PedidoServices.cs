using ProjetoLucy.Domain.Entities;
using ProjetoLucy.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucyServices.Services
{
    public class PedidoServices : IDisposable
    {

		protected PedidoRepository _pedidoRepository;

		public PedidoServices()
		{
			_pedidoRepository = new PedidoRepository();
		}

		public Pedido Add(Pedido obj)
		{
			return _pedidoRepository.Add(obj);
		}

		public Pedido Update(Pedido obj)
		{
			return _pedidoRepository.Update(obj);
		}

		public IEnumerable<Pedido> GetAll()
		{
			return _pedidoRepository.GetAll();
		}

		public Pedido GetById(int pedidoId)
		{
			return _pedidoRepository.GetById(pedidoId);
		}

        public void Dispose()
        {
			_pedidoRepository.Dispose();
        }
    }
}
