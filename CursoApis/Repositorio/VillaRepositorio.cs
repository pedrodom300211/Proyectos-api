using CursoApis.Datos;
using CursoApis.Modelos;
using CursoApis.Repositorio.IRepositorio;

namespace CursoApis.Repositorio
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly ApliccationDboContext _db;
        public VillaRepositorio(ApliccationDboContext db):base(db)
        {
            _db = db;
        }

        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;
            _db.Villas.Update(entidad);
            await _db.SaveChangesAsync();
            return entidad;
        }
    }
}
