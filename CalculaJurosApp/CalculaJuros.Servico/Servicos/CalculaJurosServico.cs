using CalculaJuros.Dominio.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Servico.Servicos
{
    public class CalculaJurosServico : ICalculaJuros
    {
        private string URL_GITHUB = "https://github.com/raidymachadohub/juros-app";
        public string ShowMeTheCode()
        {
            return URL_GITHUB;
        }

        public decimal RetornaCalculaJuros(decimal valorInicial, int Meses)
        {
            return Math.Round(valorInicial *
                              Convert.ToDecimal(Math.Pow((1 + Convert.ToDouble(this.GetRetornaJuros().Result)),
                              Convert.ToDouble(Meses))), 2);
        }

        private async Task<decimal> GetRetornaJuros()
        {
            string url = "http://localhost:5000/api/taxajuros";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string strResultado = await response.Content.ReadAsStringAsync();

                    return Convert.ToDecimal(strResultado);
                }
                else
                {
                    throw new Exception("Valor não encontrado. Verificar API Retorna Juros");
                }
            }
        }
    }
}
