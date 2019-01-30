using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class UpdateQuantidadeResponse
    {
        public ItemPedido ItemPedido { get; }
        public CarrinhoViewModel carrinhoViewModel { get; }

        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            this.carrinhoViewModel = carrinhoViewModel;
        }

    }
}
