using prueba_tecnica_cristhian_farfan_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_tecnica_cristhian_farfan_backend.Controllers
{
    public class UsuarioController:Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public JsonResult GetMontoUsuario(string nombre)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Nombre.Equals(nombre));
            if (usuario == null)
            {
                return Json(new { success = false, monto="", message = string.Format("Bienvenido, {0}. Eres un jugador nuevo. Por favor ingresa tu saldo y apuesta inicial.", nombre) }, JsonRequestBehavior.AllowGet);

            }
            var recargarSaldo = usuario.Monto == 0? "Por favor recarga para poder apostar":"Por favor ingresa tu apuesta.";
            return Json(new { success = true, monto=usuario.Monto, message = string.Format("Bienvenido de nuevo, {0}. Tu saldo es de {1}. {2}",nombre,usuario.Monto,recargarSaldo) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult CargarSaldo(string nombre, decimal monto)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return Json(new { success = false, message = "El nombre del usuario es requerido." }, JsonRequestBehavior.AllowGet);
            }

            if (monto <= 0)
            {
                return Json(new { success = false, message = "El monto debe ser mayor a cero." }, JsonRequestBehavior.AllowGet);
            }

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Nombre.ToLower() == nombre.ToLower());

            if (usuario == null)
            {
                usuario = new Usuario { Nombre = nombre, Monto = monto };
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = $"Bienvenido, {usuario.Nombre}. Se ha creado tu cuenta con un saldo de ${usuario.Monto}.",
                    monto=usuario.Monto
                }, JsonRequestBehavior.AllowGet);;
            }

            usuario.Monto += monto;
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                message = $"Saldo actualizado. Nuevo saldo para {usuario.Nombre}: ${usuario.Monto}.",
                monto=usuario.Monto
            }, JsonRequestBehavior.AllowGet);
        }


    }
}