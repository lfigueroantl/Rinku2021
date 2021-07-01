using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum TipoEmpleadoEnum : byte
    {
        [StringValue("Interno")]
        Interno = 1,
        [StringValue("Externo")]
        Externo = 2,
        
    }
}
