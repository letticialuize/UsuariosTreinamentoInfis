using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Exceptions.Usuarios
{
    public class EmailJaCadastradoException : Exception
    {
        public override string Message => 
            "O e-mail informado já está cadastrado, tente outro.";
    }
}
