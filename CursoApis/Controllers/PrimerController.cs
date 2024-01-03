using CursoApis.Datos;
using CursoApis.Modelos;
using CursoApis.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;

namespace CursoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    ///en el video se llama VillaController
    public class PrimerController : ControllerBase
    {
        private readonly ILogger<PrimerController> _logger;  

        public PrimerController(ILogger<PrimerController>logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Obtener las Villas");
            return Ok(VillaStore.VillaList);
        }
        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == 0)
            {
                _logger.LogError("Error al traer la villa con ID: " + id);
                return BadRequest();
            }

            var villa = VillaStore.VillaList.FirstOrDefault(V => V.id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CrearVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (VillaStore.VillaList.FirstOrDefault(v => v.Nombre.ToLower() == villaDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La Villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }


            if (villaDto == null)
            {
                return BadRequest();
            }
            if (villaDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            villaDto.id = VillaStore.VillaList.OrderByDescending(v => v.id).FirstOrDefault().id + 1;
            VillaStore.VillaList.Add(villaDto);
            return CreatedAtRoute("GetVilla", new { id = villaDto.id }, villaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest(ModelState);
            }
            var Villa = VillaStore.VillaList.FirstOrDefault(v => v.id == id);
            if(Villa == null)
            {
                return NotFound();
            }
            VillaStore.VillaList.Remove(Villa);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if(villaDto==null || id!=villaDto.id)
            {
                return BadRequest();
            }
            var Villa = VillaStore.VillaList.FirstOrDefault(v => v.id == id);
            Villa.Nombre = villaDto.Nombre;
            Villa.Ocupantes= villaDto.Ocupantes;
            Villa.MetrosCuadrados=villaDto.MetrosCuadrados;
            return NoContent();
        }
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialVilla(int id,JsonPatchDocument <VillaDto> patchDto)
        {
            if (patchDto == null || id==0)
            {
                return BadRequest();
            }
            var Villa = VillaStore.VillaList.FirstOrDefault(v => v.id == id);
            patchDto.ApplyTo(Villa, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
