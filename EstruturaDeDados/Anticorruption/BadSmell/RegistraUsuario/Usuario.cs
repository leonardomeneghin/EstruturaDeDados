using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstruturaDeDados.Anticorruption.BadSmell.RegistraUsuario.Exceptions;
namespace EstruturaDeDados.Anticorruption.BadSmell.RegistraUsuario
{
    public class Usuario
    {
        public string Nome { get; set; }
        public Usuario(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new UsuarioComNomeVazioException("O nome é inválido, por favor insira um nome de usuário válido.");
            Nome = nome;

        }
    }
}
