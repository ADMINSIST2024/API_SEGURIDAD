using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VersionController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Obtiene la versión actual del aplicativo",
            Description = "Devuelve la versión que está en producción del app FAB083.")]
        public async Task<IActionResult> GetVersion()
        {
            return await Task.FromResult(Ok(new
            {
                version = "1.0.4",
                url = "http://10.0.2.2:8088/app-debug.apk"
            }));
        }

    }
}
