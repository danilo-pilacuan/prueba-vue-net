using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Domain.Contracts;
using VentaEntradas.Domain.Entities;
using AutoMapper;
using VentaEntradas.Application.Dtos;
using VentaEntradas.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace VentaEntradas.Application.AppServices
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IEventoRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EventoAppService(IEventoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<EventoDto> CreateAsync(EventoCreateDto eventoCreateDto)
        {

            Evento Evento = mapper.Map<EventoCreateDto, Evento>(eventoCreateDto);

            Evento = await repository.CreateAsync(Evento);
            await unitOfWork.SaveChangesAsync();


            var EventoDto = mapper.Map<Evento, EventoDto>(Evento);


            return EventoDto;
        }

        public async Task<bool> DeleteAsync(int eventoId)
        {
            Evento Evento = await repository.GetByIdAsync(eventoId);
            if (Evento == null)
            {
                throw new ArgumentException($"El Evento con el id: {eventoId}, no existe");
            }
            repository.Delete(Evento);

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public ICollection<EventoDto> GetAll()
        {
            List<Evento> listaTiposEvento = repository.GetAllAsync().ToList();

            return listaTiposEvento.Select(x => mapper.Map<Evento, EventoDto>(x)).ToList();

        }

        public Task<EventoPaginadoDto> GetPaginated(int itemsPerPage,int pageNumber)
        {
            List<Evento> listaTiposEvento = repository.GetAllAsync().ToList();

            var lista= listaTiposEvento.Select(x => mapper.Map<Evento, EventoDto>(x)).ToList();
            int skip = pageNumber * itemsPerPage;

            int total = lista.Count;

            lista = lista.Skip(skip)
            .Take(itemsPerPage)
            .ToList();

            EventoPaginadoDto paginado = new EventoPaginadoDto
            {
                Eventos = lista,
                Total = total,
                Paginas = total / itemsPerPage
            };

            return Task.FromResult(paginado);
        }

        public async Task UpdateAsync(int eventoId, EventoUpdateDto eventoUpdateDto)
        {
            var evento = await repository.GetByIdAsync(eventoId);
            if (evento == null)
            {
                throw new ArgumentException($"El tipo Evento el id: {eventoId}, no existe");
            }

            
            evento.DescripcionEvento = eventoUpdateDto.DescripcionEvento;
            evento.LugarEvento = eventoUpdateDto.LugarEvento;
            evento.PrecioEvento = eventoUpdateDto.PrecioEvento;
            evento.FechaEvento = eventoUpdateDto.FechaEvento;

      

        await repository.UpdateAsync(evento);
            await repository.UnitOfWork.SaveChangesAsync();

            return;
        }
    }
}
