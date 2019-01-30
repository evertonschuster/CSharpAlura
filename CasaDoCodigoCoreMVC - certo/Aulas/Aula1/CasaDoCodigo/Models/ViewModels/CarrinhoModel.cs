using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    //sempre com o nome do form, pois e o form que precisa de informacoes, e pode precisar de varios objetos distintos 
    public class CarrinhoViewModel
    {
        public readonly IList<ItemPedido> itens;

        public CarrinhoViewModel(List<ItemPedido> itens)
        {
            this.itens = itens;
        }

        public IList<ItemPedido> GetItens()
        {
            return itens;
        }

        public decimal Total => itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
