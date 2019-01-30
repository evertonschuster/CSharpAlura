using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();

            List<Livros> livros = GetLivos();

            produtoRepository.SaveProdutos(livros);
        }

        private static List<Livros> GetLivos()
        {
            var json = File.ReadAllText("livros.json");

            var livros = JsonConvert.DeserializeObject<List<Livros>>(json);
            return livros;
        }

     
    }
}
