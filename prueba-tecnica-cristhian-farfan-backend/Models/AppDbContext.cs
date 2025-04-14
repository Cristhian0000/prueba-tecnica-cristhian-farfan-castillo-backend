using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prueba_tecnica_cristhian_farfan_backend.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext() : base("name=DefaultConnection") 
        {
        }
    }
}