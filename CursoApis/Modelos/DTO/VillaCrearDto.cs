using System.ComponentModel.DataAnnotations;

namespace CursoApis.Modelos.DTO
{
    public class VillaCrearDto
    {
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }

        public string Detalle { get; set; }

        public int tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public String Amenidad { get; set; }

    }
}
