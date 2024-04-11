using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Application.Dtos;

namespace VentaEntradas.Application.Contracts
{
    public interface IEventoAppService
    {
        ICollection<EventoDto> GetAll();

        Task<EventoDto> CreateAsync(EventoCreateDto EventoCreateUpdateDto);

        Task<EventoPaginadoDto> GetPaginated(int itemsPerPage, int pageNumber);
        Task UpdateAsync(int EventoId, EventoUpdateDto EventoCreateUpdateDto);

        Task<bool> DeleteAsync(int EventoId);
    }
}
