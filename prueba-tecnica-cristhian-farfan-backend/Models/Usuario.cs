using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prueba_tecnica_cristhian_farfan_backend.Models
{
    public class Usuario
    {
        [Key]
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
    }
}