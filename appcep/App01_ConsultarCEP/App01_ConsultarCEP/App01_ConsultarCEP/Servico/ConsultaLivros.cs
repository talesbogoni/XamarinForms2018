using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace App01_ConsultarCEP.Servico
{
    public class ConsultaLivros
    {
        

        public static Livro BuscarLivros(string id)
        {
            string EnderecoUrl = "http://starts1000.info/apirest/livros/{0}";
            string NovoEnderecoUrl = string.Format(EnderecoUrl, id);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoUrl);
            try
            {
                Livro livro = JsonConvert.DeserializeObject<Livro>(Conteudo);
                return livro;
            } catch (Exception e)
            {
                return null;
            }
        }

        public static List <Livro> BuscarLivros()
        {
            string EnderecoUrl = "http://starts1000.info/apirest/livros";
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(EnderecoUrl);
            try
            {
                List <Livro> livros = JsonConvert.DeserializeObject<List<Livro>>(Conteudo);
                return livros;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async System.Threading.Tasks.Task InserirLivroAsync(Livro livro)
        {
            string EnderecoUrl = "http://starts1000.info/apirest/livros";
            HttpClient wc = new HttpClient();
            var json = JsonConvert.SerializeObject(livro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await wc.PostAsync(EnderecoUrl, content);
        }

    }
}
