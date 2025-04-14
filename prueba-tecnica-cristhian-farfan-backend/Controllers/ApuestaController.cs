using prueba_tecnica_cristhian_farfan_backend.Models;
using prueba_tecnica_cristhian_farfan_backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_tecnica_cristhian_farfan_backend.Controllers
{
    public class ApuestaController : Controller
    {
        private static Random random = new Random();
        private readonly AppDbContext _context;

        public ApuestaController()
        {
            _context = new AppDbContext();
        }

        [HttpPost]
        public JsonResult CalcularPremio(ApuestaModel apuestaModel)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Nombre.Equals(apuestaModel.NombreJugador, StringComparison.OrdinalIgnoreCase));

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado." });
            }


            decimal premio = CalcularMontoPremio(apuestaModel);

            // Actualizamos el monto del usuario según el resultado
            if (apuestaModel.ResultadoJugador)
            {
                usuario.Monto += premio;
            }
            else
            {
                usuario.Monto -= apuestaModel.MontoApostado;
                premio = 0;
            }
            _context.SaveChanges();


            return Json(new { success = true, premio, montoActual = usuario.Monto }); ;
        }
        private decimal CalcularMontoPremio(ApuestaModel apuesta)
        {
            switch (apuesta.TipoDeApuesta)
            {
                case TipoApuesta.COLOR:
                    return apuesta.MontoApostado / 2;

                case TipoApuesta.COLOR_PAR:
                    return apuesta.MontoApostado * 2;

                case TipoApuesta.NUMERO:
                    return apuesta.MontoApostado * 3;

                default:
                    return 0;
            }
        }

    }

}