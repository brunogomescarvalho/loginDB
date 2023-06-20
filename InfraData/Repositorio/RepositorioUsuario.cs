using Dominio;
using InfraData.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private DaoUsuario daoUsuario;

        public RepositorioUsuario(DaoUsuario daoUsuario)
        {
            this.daoUsuario = daoUsuario;
        }

        public Usuario BuscarPorId(int id)
        {
            return daoUsuario.BuscarPorId(id);
        }

        public List<Usuario> BuscarTodos()
        {
            return daoUsuario.BuscarTodos();
        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            return daoUsuario.BuscarUsuario(usuario);
        }

        public bool Cadastrar(Usuario usuario)
        {
           return daoUsuario.Cadastrar(usuario);
        }

        public bool Editar(int id, Usuario usuario)
        {
            Usuario usuarioParaEditar = daoUsuario.BuscarPorId(id);

            usuarioParaEditar.NomeUsuario = usuario.NomeUsuario;
            usuarioParaEditar.Senha = usuario.Senha;

            return daoUsuario.Editar(usuarioParaEditar);
        }

        public bool Excluir(int id)
        {
            return daoUsuario.Excluir(id);
        }
    }
}
