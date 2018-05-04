using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppConsultaCep.Servicos.Modelo;
using Newtonsoft.Json;
namespace AppConsultaCep.Servicos
{
    public class viaCep
    {
        public static string enderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco buscarEnderecoCep(string cep)
        {
            string noveEndereco = string.Format(enderecoUrl, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(noveEndereco);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if (end.cep == null) return null;
           
            return end;
        }
    }
}
