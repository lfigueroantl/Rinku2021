using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class Usuarios
    {
        public bool UserNamePassExist(string userName, string pass)
        {
            bool result;

            using (var r = new DAL.Repository<Usuario>())
            {
                result = r.Retrieve(x => x.NombreUsuario == userName && x.Contraseña == pass) != null;
            }

            return result;
        }
    }
}
