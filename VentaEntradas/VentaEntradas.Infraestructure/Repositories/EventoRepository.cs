using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Domain.Contracts;
using VentaEntradas.Domain.Entities;

namespace VentaEntradas.Infraestructure.Repositories
{
    public class EventoRepository : VentaEntradasRepository<Evento, int>, IEventoRepository
    {
        public EventoRepository(VentaEntradasDbContext context) : base(context)
        {
        }
    }
}
