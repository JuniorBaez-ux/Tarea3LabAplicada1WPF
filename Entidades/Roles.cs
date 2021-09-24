using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3LabAplicada1.Entidades
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
    }
}
