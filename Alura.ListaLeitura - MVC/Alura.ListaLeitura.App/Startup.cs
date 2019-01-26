using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Mvc;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup 
    {
        public void ConfigureServices(IServiceCollection services )
        {
            //services.AddRouting();
            services.AddMvc();
        }


        //Executa quando inicializa o servidor
        public void ConfigureOLD(IApplicationBuilder app)
        {
            //var builder = new RouteBuilder(app);
            //builder.MapRoute("Livros/ParaLer", LivrosController.ParaLer);
            //builder.MapRoute("Livros/Lendo", LivrosController.Lendo);
            //builder.MapRoute("Livros/Lidos", LivrosController.Lidos);
            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroController.NovoLivroParaLer);
            //builder.MapRoute("Livros/Detalhes/{id:int}", LivrosController.Detalhes);
            //builder.MapRoute("Cadastro/ExibeFormulario", CadastroController.ExibeFormulario);
            //builder.MapRoute("Cadastrar/Incluir", CadastroController.Incluir);

            //var rotas = builder.Build();
            //app.UseRouter(rotas);

            //app.Run(Roteamento); removido pois o Roteamento era feito na unha
        }

        //Executa quando inicializa o servidor
        public void ConfigureOLD2(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            var rotas = builder.Build();
            app.UseRouter(rotas);

            //app.Run(Roteamento); removido pois o Roteamento era feito na unha
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();//nao se deve usar estas configuracao em producao 
            app.UseMvcWithDefaultRoute();
        }


        //[ { } ]
        public Task Roteamento(HttpContext context)
        {
            ////Livros/ParaLer
            ////Livros/Lendo
            ////Livros/Lidos
            //var repo = new LivroRepositorioCSV();

            ////O conteudo do dicionario é uma referencia de metodo
            //var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            //{
            //    {"/Livros/ParaLer",LivrosController.ParaLer },
            //    {"/Livros/Lendo",LivrosController.Lendo},
            //    {"/Livros/Lidos",LivrosController.Lidos }
            //};

            //if (caminhosAtendidos.ContainsKey(context.Request.Path))
            //{
            //    var metodo = caminhosAtendidos[context.Request.Path];//Pega o metodo no Dicionario
            //    return metodo.Invoke(context);//invoco ele, com odevido parametro
            //}

            //context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho Inezistente");
        }


    }
}