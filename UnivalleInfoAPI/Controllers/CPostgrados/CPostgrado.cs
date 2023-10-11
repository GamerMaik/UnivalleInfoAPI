using ENTIDADES.EPostgrado;
using LNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;

namespace UnivalleInfoAPI.Controllers.CPostgrados
{
    [ApiController]
    [Route("c")]
    public class CPostgrado : ControllerBase
    {
        #region Atributos
        private readonly LNInformacionUnivalle LNUnivalleInfo;
        #endregion

        #region Constructor
        public CPostgrado() 
        {
            LNUnivalleInfo = new LNInformacionUnivalle();
        }
        #endregion

        #region Metodos Publicos
        [HttpPost("InsertarPostgrado")]
        public IActionResult AdicionarPostgrado([FromBody] EIPostgrado eIPostgrado)
        {
            var response = LNUnivalleInfo.Adicionar_Postgrado_EIPostgrado(eIPostgrado);
            return Ok(response);
        }

        [HttpGet("ObtenerPostgrado")]
        public IActionResult ObtenerPostgrados()
        {
            var response = LNUnivalleInfo.Obtener_Postgrados();
            return Ok(response);
        }

        [HttpPut("ActualizarPostgrado")]
        public IActionResult ActualizarPostgrado([FromBody] EIPostgrado eIPostgrado)
        {
            var response = LNUnivalleInfo.Actualizar_Postgrado_EIPostgrado(eIPostgrado);
            return Ok(response);
        }

        [HttpDelete("EliminarPostgrado/{postgradoId}")]
        public IActionResult EliminarPostgrado(int postgradoId)
        {
            var response = LNUnivalleInfo.Eliminar_Postgrado_PostgradoId(postgradoId);

            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
