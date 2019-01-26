using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alura.ListaLeitura.App
{
    public class HTMLUteis
    {

        public static string CarregaArquivoFormulario(string v)
        {
            var nomeCompletoArquivo = $"../../../HTML/{v}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
