using CalculaJuros.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJurosApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJuros _calculaJuros;
        public CalculaJurosController(ICalculaJuros calculaJuros)
        {
            _calculaJuros = calculaJuros;
        }

        [HttpGet("calculoJuros")]
        public ActionResult<decimal> CalculoJuros(decimal valorInicial, int meses)
        {
            try
            {
                return _calculaJuros.RetornaCalculaJuros(valorInicial, meses);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("showMeTheCode")]
        public ActionResult<string> ShowMeTheCode()
        {
            try
            {
                return _calculaJuros.ShowMeTheCode();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }
    }
}
