using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using ConsultaCep.Model;

namespace ConsultaCep
{
    public class ViaCep
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);
            WebClient wc = new WebClient();
            try
            {
                string Conteudo = wc.DownloadString(NovoEnderecoUrl);
                Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
                if (String.IsNullOrEmpty(end.localidade))
                    return null;
                return end;
            } catch (Exception e)
            {
                return null;
            }
        }
    }
}
