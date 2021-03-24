using Microsoft.AspNetCore.Mvc;
using RetornaJuros.Dominio.Interface;

namespace RetornaJurosApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJuros _taxaJuros;
        public TaxaJurosController(ITaxaJuros taxaJuros)
        {
            _taxaJuros = taxaJuros;
        }


        [HttpGet("taxaJuros")]
        public ActionResult<double> Get()
        {
            return _taxaJuros.RetornaTaxaJuros();
        }
    }
}
