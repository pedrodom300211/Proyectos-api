using CursoApis.Datos;
using CursoApis.Modelos;
using CursoApis.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    ///en el video se llama VillaController
    public class PrimerController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>>GetVillas()
        {
            return Ok(VillaStore.VillaList); 
        }
        [HttpGet("id:int",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult< VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
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
            if(villaDto == null)
            {
                return BadRequest();
            }    
            if(villaDto.id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            villaDto.id = VillaStore.VillaList.OrderByDescending(v => v.id).FirstOrDefault().id + 1;
               VillaStore.VillaList.Add(villaDto);
            return CreatedAtRoute("GetVilla",new {id=villaDto.id},villaDto);
        }

    }
}
