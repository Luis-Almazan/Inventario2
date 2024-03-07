using Inventario2.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Inventario2.Controllers
{
    [ApiController]
    [Route("Catalogos")]
    public class Catalogos : ControllerBase
    {
        [HttpGet]
        [Route("ListadoServers")]
        public dynamic ListadoServers()
        {
            using (var dbContext = new ModelContext())
            {
                // Realizar una consulta para obtener todos los usuarios
                var servers = dbContext.Puertos.ToList();

                return servers;


            }



        }
    }
}
