using EstruturaDeDados.Anticorruption.BadSmell.RegistraUsuario.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.BadSmell.RegistraUsuario
{
    public class RegistraUsuario
    {
        private List<Usuario> _usuarios;
        RegistraUsuario()
        {
            _usuarios = new List<Usuario>();
        }
        public void OLDRegistraUsuarios(string nome)
        {
            try
            {
                if (nome != null)
                {
                    if (!string.IsNullOrEmpty(nome))
                    {
                        Usuario usuario = new Usuario(nome);
                        if (!_usuarios.Contains(usuario))
                        {
                            _usuarios.Add(usuario);
                        }
                        else
                        {
                            throw new UsuarioJaRegistradoException($"Já existe um usuário registrado com o nome {nome}, por favor utilize outro nome de usuário.");
                        }
                    }
                    else
                    {
                        throw new UsuarioComNomeVazioException("O nome está vazio, por favor insira um nome válido");
                    }
                }
                else
                {
                    throw new UsuarioInexistenteException("Não pode registrar usuário inexistente");
                }
            }
            catch (UsuarioComNomeVazioException ex)
            {
                throw new UsuarioComNomeVazioException(ex.Message);
            }
            catch (UsuarioInexistenteException ex)
            {
                throw new UsuarioInexistenteException(ex.Message);
            }
            catch (UsuarioJaRegistradoException ex)
            {
                throw new UsuarioJaRegistradoException(ex.Message);
            }
        }
        public void RegistraUsuarios(string nome)
        {
            try
            {
                Usuario usuario = new Usuario(nome);
                if (_usuarios.Contains(usuario))
                {
                    throw new UsuarioJaRegistradoException($"Já existe um usuário registrado com o nome {nome}, por favor utilize outro nome de usuário.");
                }
                _usuarios.Add(usuario);

            }
            catch (UsuarioComNomeVazioException ex)
            {
                throw new UsuarioComNomeVazioException(ex.Message);
            }
            catch (UsuarioInexistenteException ex)
            {
                throw new UsuarioInexistenteException(ex.Message);
            }
            catch (UsuarioJaRegistradoException ex)
            {
                throw new UsuarioJaRegistradoException(ex.Message);
            }
        }
    }
}
