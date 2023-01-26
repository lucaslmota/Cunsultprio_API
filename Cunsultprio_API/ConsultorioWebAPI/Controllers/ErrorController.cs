using Consultorio.Core.Shared.ModelViews;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsultorioWebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var contexto = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = contexto?.Error;


            Response.StatusCode = 500;
            var idError = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return new ErrorResponse(idError  );
        }
    }
}
