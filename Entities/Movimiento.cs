//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movimiento
    {
        public int Codigo { get; set; }
        public int NumeroEmpleado { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool CubrioTurno { get; set; }
        public byte CantidadEntregas { get; set; }
        public byte RolCubrio { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
