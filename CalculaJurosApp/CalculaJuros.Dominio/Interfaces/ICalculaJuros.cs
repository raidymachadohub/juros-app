using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CalculaJuros.Dominio.Interfaces
{
    public interface ICalculaJuros
    {
        decimal RetornaCalculaJuros(decimal valorInicial, int Meses);
        string ShowMeTheCode();
    }
}
