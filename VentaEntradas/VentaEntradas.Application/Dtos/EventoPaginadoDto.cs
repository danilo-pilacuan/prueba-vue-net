using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaEntradas.Application.Dtos
{
    public class EventoPaginadoDto
    {
        public IEnumerable<EventoDto> Eventos { get; set; }
        public int Paginas { get; set; }
        public int Total { get; set; }
    }
}
