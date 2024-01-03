using CursoApis.Modelos.DTO;

namespace CursoApis.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>
        {
            new VillaDto{id=1, Nombre="Vista a la picina",Ocupantes=3,MetrosCuadrados=50},
            new VillaDto{id=2, Nombre="Vista a la Playa", Ocupantes=4, MetrosCuadrados=80}

        };
    }
}
