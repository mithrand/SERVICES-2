using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SERVICES.MODEL;


namespace SERVICES.REPO
{
    public  interface IUsuarioRepo
    {
        IQueryable<Usuario> Usuarios { get; }
    }
}
