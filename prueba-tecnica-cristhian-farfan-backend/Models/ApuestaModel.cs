using prueba_tecnica_cristhian_farfan_backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_tecnica_cristhian_farfan_backend.Models
{
    public class ApuestaModel
    {
        public string NombreJugador { get; set; }

        public decimal MontoApostado { get; set; }
        public TipoApuesta TipoDeApuesta { get; set; }
 
        public bool ResultadoJugador { get; set; }
    }
 
}