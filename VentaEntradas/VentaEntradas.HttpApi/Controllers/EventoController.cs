using VentaEntradas.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using VentaEntradas.Application.AppServices;
using VentaEntradas.Application.Contracts;
using VentaEntradas.Application.Dtos;

namespace ComercioElectronico.HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors]
//[Authorize]
public class EventoController : ControllerBase
{
    private readonly IEventoAppService eventoAppService;
    public EventoController(IEventoAppService eventoAppService)
    {
        this.eventoAppService = eventoAppService;
    }

    [HttpGet]
    public ICollection<EventoDto> obtenerEventos()
    {
        return eventoAppService.GetAll();
    }
    
    [HttpGet("{itemsPerPage}/{pageNumber}")]
    public Task<EventoPaginadoDto> obtenerEventosPaginado(int itemsPerPage, int pageNumber)
    {
        return eventoAppService.GetPaginated(itemsPerPage,pageNumber-1);
    }

    [HttpPost]
    public async Task<EventoDto> registrar([FromBody] EventoCreateDto eventoCreateDto)
    {
        return await eventoAppService.CreateAsync(eventoCreateDto);
    }

    [HttpPut("{eventoId}")]
    public async Task actualizar(int eventoId, [FromBody] EventoUpdateDto eventoUpdateDto)
    {
        await eventoAppService.UpdateAsync(eventoId, eventoUpdateDto);
    }

    [HttpDelete("{eventoId}")]
    public async Task<bool> DeleteAsync(int eventoId)
    {

        return await eventoAppService.DeleteAsync(eventoId);

    }
}