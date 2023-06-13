using Microsoft.AspNetCore.Mvc;

namespace soffapp.Controllers
{
  [Route("[controller]")]
    public class VentasController : Controller
    {
        private readonly ILogger<VentasController> _logger;

        public VentasController(ILogger<VentasController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // COLUMNAS
            //- fecha de venta
            //- metodo de pago
            //- total venta
            //- tipo de venta
            //- cantidad de ordenes
            //- cedula
            //- nombre del cliente.


            return View();
        }
    }
}