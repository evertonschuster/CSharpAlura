using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CasaDoCodigo.DataService;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Produto> GetProduto()
        {
            return context.Set<Produto>().ToList();
        }

        public void SaveProdutos(List<Livros> livros)
        {
            foreach (var item in livros)
            {
                if (!dbSet.Where(p => p.Codigo == item.Codigo).Any())
                {
                    dbSet.Add(new Produto(item.Codigo, item.Nome, item.Preco));
                }
            }

            context.SaveChanges();
        }
    }
    public class Livros
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
