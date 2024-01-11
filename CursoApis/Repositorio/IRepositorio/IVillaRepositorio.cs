using CursoApis.Modelos;

namespace CursoApis.Repositorio.IRepositorio
{
    public interface IVillaRepositorio:IRepositorio<Villa>
    {

        Task<Villa> Actualizar(Villa entidad);

    }
}
