using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class EmpleadoDTO: Empleado
    {
        public string NombreRol { get; set; }
        public string NombreTipo { get; set; }
        public bool PuedeCubrir { get; set; }
        public byte BonoRol { get; set; }
        public byte BaseRol { get; set; }
        public byte HorasRol { get; set; }
        public byte ExtraPorEntregas { get; set; }
        public byte PorcValeDespensa { get; set; }
    }
}
