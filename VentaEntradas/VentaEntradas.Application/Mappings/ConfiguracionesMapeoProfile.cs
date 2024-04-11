using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Application.Dtos;
using VentaEntradas.Domain.Entities;

namespace VentaEntradas.Application.Mappings
{
    public class ConfiguracionesMapeoProfile : Profile
    {
        public ConfiguracionesMapeoProfile()
        {
            CreateMap<Evento, EventoDto>();
            CreateMap<Evento, EventoCreateDto>();
            CreateMap<Evento, EventoUpdateDto>();

            CreateMap<EventoDto, Evento>();
            CreateMap<EventoCreateDto, Evento>();
            CreateMap<EventoUpdateDto, Evento>();
        }
    }
}
