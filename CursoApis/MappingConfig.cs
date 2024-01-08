using AutoMapper;
using CursoApis.Datos;
using CursoApis.Modelos;
using CursoApis.Modelos.DTO;

namespace CursoApis
{
    public class MappingConfig:Profile
    {

        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>();
            CreateMap<VillaDto, Villa>();
            CreateMap<Villa, VillaCrearDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();


        }
    }
}
