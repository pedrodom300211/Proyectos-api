using AutoMapper;
using CursoApis.Datos;
using CursoApis.Modelos;
using CursoApis.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;

namespace CursoApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    ///en el video se llama VillaController
    public class PrimerController : ControllerBase
    {
        private readonly ILogger<PrimerController> _logger;  
        private readonly ApliccationDboContext _db;
        private readonly IMapper _mapper;

        public PrimerController(ILogger<PrimerController>logger, ApliccationDboContext db, IMapper mapper)
        {
            _logger = logger;
            _db=db;
            _mapper=mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            _logger.LogInformation("Obtener las Villas");
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList));
        
        }



        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
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

            ///var villa = VillaStore.VillaList.FirstOrDefault(V => V.id == id);
            var villa = await  _db.Villas.FirstOrDefaultAsync(v=> v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDto>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CrearVilla([FromBody] VillaCrearDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _db.Villas.FirstOrDefaultAsync(v => v.Nombre.ToLower() == createDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La Villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }


            if (createDto == null)
            {
                return BadRequest();
            }


            ///Cargas objeto Villa

            Villa modelo = _mapper.Map<Villa>(createDto);
            
            ///Agregas objeto
           await _db.Villas.AddAsync(modelo);
            ///Guardas
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVilla", new { id = modelo.Id },modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task <IActionResult> DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest(ModelState);
            }
            ///cargas el id a eliminar
            var Villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);
            if(Villa == null)
            {
                return NotFound();
            }
            ///Lo Eliminas
            _db.Villas.Remove(Villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task< IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto UpdateDto)
        {
            if(UpdateDto == null || id!= UpdateDto.id)
            {
                return BadRequest();
            }
            
            Villa modelo= _mapper.Map<Villa>(UpdateDto);
            _db.Villas.Update(modelo);
           await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialVilla(int id,JsonPatchDocument <VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id==0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);
            
            if(villa== null)return BadRequest();    

            patchDto.ApplyTo(villaDto, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa modelo = _mapper.Map<Villa>(villaDto);
            _db.Villas.Update(modelo);
           await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}
