﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaEntradas.Application.Dtos
{
    public class EventoCreateDto
    {
        public string? DescripcionEvento { get; set; }
        public string? LugarEvento { get; set; }
        public decimal PrecioEvento { get; set; }
        public DateTime FechaEvento { get; set; }

    }
}
