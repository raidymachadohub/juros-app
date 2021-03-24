using RetornaJuros.Dominio.Interface;

namespace RetornaJuros.Servico.Servicos
{
    public class TaxaJurosServico : ITaxaJuros
    {
        private double TAXA_JUROS = 0.01;
        public double RetornaTaxaJuros()
        {
            return TAXA_JUROS;
        }
    }
}
