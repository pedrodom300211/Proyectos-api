using System.ComponentModel.DataAnnotations;

namespace CursoApis.Modelos.DTO
{
    public class VillaUpdateDto
    {
        [Required]
        public int id {  get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public string Detalle { get; set; }


        
        public int tarifa { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        [Required] 
        public int MetrosCuadrados { get; set; }
        [Required] 
        public string ImagenUrl { get; set; }
        public String Amenidad { get; set; }

    }
}
