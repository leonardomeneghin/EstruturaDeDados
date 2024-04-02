using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.BadSmell.RegistraUsuario.Exceptions
{
    public class UsuarioInexistenteException : Exception
    {
        public UsuarioInexistenteException(string message) : base(message)
        {

        }
    }
}
