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
    public class Movimientos
    {
        public void Guardar(MovimientoDTO item)
        {
            var isNew = false;

            using (var r = new Repository<Movimiento>())
            {
                var itemSave = r.Retrieve(x => x.Codigo.Equals(item.Codigo));

                isNew = itemSave == null;

                if (isNew)
                {
                    itemSave = new Movimiento();
                }
                itemSave.NumeroEmpleado = item.NumeroEmpleado;
                itemSave.Fecha = item.Fecha;
                itemSave.CubrioTurno = item.CubrioTurno;
                itemSave.CantidadEntregas = item.CantidadEntregas;
                itemSave.RolCubrio = item.RolCubrio;

                if (isNew)
                {
                    r.Create(itemSave);
                }
                else
                {
                    r.Update(itemSave, x => x.First(y => y.Codigo.Equals(itemSave.Codigo)));
                }
            }

        }

        public void Eliminar(int codigo)
        {
            using (var r = new Repository<Movimiento>())
            {
                var itemSave = r.Retrieve(x => x.Codigo.Equals(codigo));
                r.Delete(itemSave);
            }
        }

        public MovimientoDTO obtenerPorCodigo(int codigo, Expression<Func<Movimiento, MovimientoDTO>> select)
        {
            MovimientoDTO result = null;

            using (var r = new Repository<Movimiento>())
            {
                result = r.Retrieve(x => x.Codigo == codigo, select);
            }

            return result;
        }
        public List<MovimientoDTO> Filter(Expression<Func<Movimiento, MovimientoDTO>> select)
        {
            var result = new List<MovimientoDTO>();

            using (var r = new Repository<Movimiento>())
            {
                result = r.Filter(select);
            }

            return result;
        }
        public CatalogoImpuestoDTO obtenerISR(Expression<Func<CatalogoImpuesto, CatalogoImpuestoDTO>> select)
        {
            CatalogoImpuestoDTO result = null;

            using (var r = new Repository<CatalogoImpuesto>())
            {
                result = r.Retrieve(x => x.Codigo == 1, select);
            }

            return result;
        }
    }
}
