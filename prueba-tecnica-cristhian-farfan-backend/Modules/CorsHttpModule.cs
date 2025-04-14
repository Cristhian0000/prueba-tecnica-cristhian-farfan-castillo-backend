using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_tecnica_cristhian_farfan_backend.Modules
{
    public class CorsHttpModule:IHttpModule
    {
        public void Init(HttpApplication context)
        {
            // Maneja el evento BeginRequest
            context.BeginRequest += (sender, e) =>
            {
                // Agregar las cabeceras CORS a la respuesta
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");  // Permite cualquier origen
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS"); // Métodos permitidos
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With, Origin, Authorization"); // Cabeceras permitidas

                // Si la solicitud es de tipo OPTIONS (preflight), finalizarla para evitar que siga procesando
                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    HttpContext.Current.Response.StatusCode = 200;
                    HttpContext.Current.Response.End();
                }
            };
        }

        public void Dispose()
        {
            // No se necesita ninguna acción en este método
        }
    }
}