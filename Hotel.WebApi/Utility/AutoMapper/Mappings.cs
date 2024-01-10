using AutoMapper;
using Hotel.BusinessLogic.DTO.Cliente;
using Hotel.BusinessLogic.DTO.Habitacion;
using Hotel.BusinessLogic.DTO.Reservacion;
using Hotel.BusinessLogic.DTO.TipoHabitacion;
using Hotel.BusinessLogic.DTO.Usuario;
using Hotel.Entities;

namespace Hotel.WebApi.Utility.AutoMapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<ClienteDTO, ThtCliente>()
               .ReverseMap();

            CreateMap<HabitacionDTO, ThtHabitacion>()
               .ReverseMap();

            CreateMap<ThtHabitacion, HabitacionDTO>()
                .ForMember(dest => dest.TcNomTipoHabitacion, opt => opt.MapFrom(src => src.TnIdTipoHabitacionNavigation.TcNomTipoHabitacion))
                .ForMember(dest => dest.TcTamanoHabitacion, opt => opt.MapFrom(src => src.ThtDetallehabitacionNavigation.TcTamanoHabitacion))
                .ForMember(dest => dest.TcDscAmenidades, opt => opt.MapFrom(src => src.ThtDetallehabitacionNavigation.TcDscAmenidades))
               .ReverseMap();

            CreateMap<ReservacionDTO, ThtReservacion>()
               .ReverseMap();

            CreateMap<ThtReservacion, ReservacionDTO>()
                .ForMember(dest => dest.TcNombre, opt => opt.MapFrom(src => $"{src.TnIdClienteNavigation.TcNombre} {src.TnIdClienteNavigation.TcAp1} {src.TnIdClienteNavigation.TcAp2}"))
                .ForMember(dest => dest.TcNombreHabitacion, opt => opt.MapFrom(src => src.TnIdHabitacionNavigation.TcNombreHabitacion))
               .ReverseMap();

            CreateMap<TipoHabitacionDTO, ThtTipohabitacion>()
               .ReverseMap();

            CreateMap<UsuarioDTO, ThtUsuario>()
               .ReverseMap();

            //

            CreateMap<ClienteCreateDTO, ThtCliente>()
               .ReverseMap();
           
            CreateMap<HabitacionCreateDTO, ThtHabitacion>()
               .ReverseMap();

            CreateMap<ReservacionCreateDTO, ThtReservacion>()
               .ReverseMap();

            CreateMap<TipoHabitacionCreateDTO, ThtTipohabitacion>()
               .ReverseMap();

            CreateMap<RegisterDTO, ThtUsuario>()
               .ReverseMap();
        }
    }
}
