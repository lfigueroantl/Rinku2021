using DAL;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Empleados
    {

        public void Guardar(EmpleadoDTO item)
        {
            var isNew = false;

            using (var r = new Repository<Empleado>())
            {
                var itemSave = r.Retrieve(x => x.Numero.Equals(item.Numero));

                isNew = itemSave == null;

                if (isNew)
                {
                    itemSave = new Empleado();
                }
                itemSave.Numero = item.Numero;
                itemSave.Nombre = item.Nombre;
                itemSave.ApellidoPaterno = item.ApellidoPaterno;
                itemSave.ApellidoMaterno = item.ApellidoMaterno;
                itemSave.Rol = item.Rol;
                itemSave.Tipo = item.Tipo;

                if (isNew)
                {
                    r.Create(itemSave);
                }
                else
                {
                    r.Update(itemSave, x => x.First(y => y.Numero.Equals(itemSave.Numero)));
                }
            }

        }

        public void Eliminar(int numEmpleado)
        {
            using (var r = new Repository<Empleado>())
            {
                var itemSave = r.Retrieve(x => x.Numero.Equals(numEmpleado));
                r.Delete(itemSave);
            }
        }

        public EmpleadoDTO obtenerPorNumero(int numero, Expression<Func<Empleado, EmpleadoDTO>> select)
        {
            EmpleadoDTO result = null;

            using (var r = new Repository<Empleado>())
            {
                result = r.Retrieve(x => x.Numero == numero, select);
            }

            return result;
        }
        public List<EmpleadoDTO> Filter(Expression<Func<Empleado, EmpleadoDTO>> select)
        {
            var result = new List<EmpleadoDTO>();

            using (var r = new Repository<Empleado>())
            {
                result = r.Filter(select);
            }

            return result;
        }
    }
}
