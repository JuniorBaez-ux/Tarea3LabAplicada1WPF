using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3LabAplicada1.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Tarea3LabAplicada1.DAL
{
    public class  Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Roles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\datosUsuarios.Db");
        }
    }
}
