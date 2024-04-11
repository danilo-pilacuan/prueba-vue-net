using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Domain.Entities;

namespace VentaEntradas.Domain.Contracts
{
    public interface IEventoRepository : IRepository<Evento,int>
    {
    }
}
