using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea3LabAplicada1.Entidades
{
     public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public int RolID { get; set; }
        public string Alias { get; set; }
        public bool Activo { get; set; }

        public Usuarios()
        {
            UsuarioID = 0;
            FechaIngreso = DateTime.Now;
            Alias = string.Empty;
            Nombres = string.Empty;
            Email = string.Empty;
            Activo = false;
        }

        public Usuarios(int usuarioId, DateTime fechaIngreso, string alias, string nombres, string email, bool activo)
        {
            UsuarioID = usuarioId;
            FechaIngreso = fechaIngreso;
            Alias = alias;
            Nombres = nombres;
            Email = email;
            Activo = activo;
        }
    }
}
