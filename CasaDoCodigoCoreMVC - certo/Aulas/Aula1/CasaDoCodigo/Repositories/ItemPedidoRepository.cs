using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetPedido(int id);

        void RemoveItemPedido(int id);
    }
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

        public ItemPedido GetPedido(int id)
        {
            return dbSet.Where(i => i.Id == id)
                .SingleOrDefault();
        }

        public void RemoveItemPedido(int id)
        {
            dbSet.Remove(GetPedido(id));
        }
    }
}
