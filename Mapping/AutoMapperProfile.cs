using AutoMapper;
using TrabajoPracticoFinal.Models;

namespace TrabajoPracticoFinal.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapea de Articulo a ArticuloDto
            CreateMap<Articulo, ArticuloDto>();
            // Si quieres mapear en la dirección contraria, de ArticuloDto a Articulo:
            CreateMap<ArticuloDto, Articulo>();
        }
    }
}
