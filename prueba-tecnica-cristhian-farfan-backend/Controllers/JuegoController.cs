using prueba_tecnica_cristhian_farfan_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_tecnica_cristhian_farfan_backend.Controllers
{
    public class JuegoController:Controller
    {
        private static Random random = new Random();

        [HttpGet]
        public JsonResult GetRandomNumberAndColor()
        {
            int numero = random.Next(0, 37); // Número aleatorio entre 0 y 36
            string color = GetColor(numero);

            var result = new
            {
                numero,
                color
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string GetColor(int numero)
        {
            // Lógica para determinar el color
            if (numero == 0)
                return "green"; // El número 0 es verde
            else if (new[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 }.Contains(numero))
                return "red"; // Números rojos
            else
                return "black"; // Números negros
        }
    }
}