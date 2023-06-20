using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IRepositorioUsuario
    {
        bool Cadastrar(Usuario usuario);

        List<Usuario>BuscarTodos();

        Usuario BuscarUsuario(Usuario usuario);

        bool Excluir(int id);

        bool Editar(int id, Usuario usuario);

        Usuario BuscarPorId(int id);
    }
}
