using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaEntradas.Domain.Entities
{
    public class Evento
    {
        //public Guid GuiId { get; set; }
        public int Id { get; set; }
        public string? DescripcionEvento { get; set; }
        public string? LugarEvento { get; set; }
        public decimal PrecioEvento { get; set; }
        public DateTime FechaEvento { get; set; }

    }
}
