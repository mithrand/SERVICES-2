using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICES.MODEL
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Observaciones { get; set; }
        public bool Activo { get; set; }
        public string Email { get; set; }
        public DateTime FechaCaducidadPassword { get; set; }
    }
}
