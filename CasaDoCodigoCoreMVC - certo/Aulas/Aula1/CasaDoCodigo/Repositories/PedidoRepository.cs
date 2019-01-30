using CasaDoCodigo.Controllers;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuandidade(ItemPedido itemPedido);

        Pedido UpdateCadastro(Cadastro cadastro);
    }
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAcessor;
        public IItemPedidoRepository itemPedidoRepository { get; }

        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(ApplicationContext context, IHttpContextAccessor contextAcessor, IItemPedidoRepository itemPedidoRepository, ICadastroRepository cadastroRepository) : base(context)
        {
            this.contextAcessor = contextAcessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = context.Set<Produto>()
                .Where(p => p.Codigo == codigo)
                .SingleOrDefault();

            if(produto == null)
            {
                throw new ArgumentException("produto nao encontrado");
            }

            var pedido = GetPedido();
            var itemPedido = context.Set<ItemPedido>()
                .Where(iP => iP.Produto.Codigo == codigo && iP.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                context.Set<ItemPedido>().Add(itemPedido);

                context.SaveChanges();
            }


        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();             //se ele achar somente 1, ele traz o objeto senao vme null

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                context.SaveChanges();

                SetPedidoId(pedido.Id);
            }


            return pedido;

        }

        private int? GetPedidoId()
        {
            return contextAcessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAcessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuandidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = itemPedidoRepository.GetPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if(itemPedidoDB.Quantidade == 0)
                {
                    itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                context.SaveChanges();

                var carrinhoViwModel = new CarrinhoViewModel(GetPedido().Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViwModel);
            }

            throw new ArgumentException("Itempedido nao encontrado");
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            var pedido = GetPedido();
            cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;

        }
    }
}
