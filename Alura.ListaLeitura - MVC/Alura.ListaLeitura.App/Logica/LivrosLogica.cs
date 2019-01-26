using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {

        public IEnumerable<Livro> Livros {get;set;}
        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HTMLUteis.CarregaArquivoFormulario("formulario");
            return context.Response.WriteAsync(html);
        }

        public  string  Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }


        public static Task ParaLer(HttpContext context)//OLD
        {
            //var repo = new LivroRepositorioCSV();
            //return context.Response.WriteAsync(repo.ParaLer.ToString());


            var repo = new LivroRepositorioCSV();
            var conteudoArquivo = HTMLUteis.CarregaArquivoFormulario("paraLer");//#NOVO-ITEM#

            foreach (var item in repo.ParaLer.Livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{item.Titulo} - {item.Autor}</li>#NOVO-ITEM#");
            }
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");
            return context.Response.WriteAsync(conteudoArquivo);

        }

        public IActionResult ParaLer()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.ParaLer.Livros;

            return View("paraLer");

        }

        public IActionResult Lendo()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lendo.Livros;
            return View("paraLer");

        }

        public IActionResult Lidos()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lidos.Livros;
            return View("paraLer");

        }

        public string Teste()
        {
            return "Teste";
        }

    }
}
