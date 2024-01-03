using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace CursoApis.Modelos
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        [Required]
        public int  Tarifa  { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public  string imageUrl { get; set; }

        public string Amenidad { get; set; }
        public DateTime FechaCreacion { get; set; }



        public DateTime FechaActualizacion { get; set; }
    }
}
