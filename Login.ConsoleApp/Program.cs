using Dominio;
using InfraData.DAO;
using InfraData.Repositorio;
using Login.ConsoleApp.Menus;

namespace Login.ConsoleApp
{
    public class Program
    {

       private static IRepositorioUsuario repositorio = new RepositorioUsuario(new DaoUsuario());



        static void Main(string[] args)
        {
           while(true)
            {
                Console.Clear();
                Console.WriteLine("Hello, World!");
                Console.WriteLine("Digite 1 para Logar");
                Console.WriteLine("Digite 2 para Cadastrar");
                Console.WriteLine("Digite 3 para Ver todos");
                Console.WriteLine("Digite 4 para Editar");
                Console.WriteLine("Digite 5 para Excluir");
                Console.WriteLine("Digite 6 para Sair");



                string opcao = Console.ReadLine()!;

                if (opcao == "1")
                {
                    Logar();
                }
                else if (opcao == "2")
                {
                    Cadastrar();
                }
                else if (opcao == "3")
                {
                    VerTodos();
                }
                else if (opcao == "4")
                {
                    Editar();
                }
                else if (opcao == "5")
                {
                    Excluir();
                }
                else if (opcao == "6")
                {
                    break;
                }
                else
                {
                    continue;
                }

            }
        }

        private static void Editar()
        {
            Console.Clear();

            Console.WriteLine("Informe o id para editar");

            int id = Convert.ToInt32(Console.ReadLine()!);

            Console.Clear();
            Console.WriteLine("Digite seu login");
            string login = Console.ReadLine()!;

            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine()!;

            Usuario usuario = new Usuario(login, senha);

            bool editou = repositorio.Editar(id, usuario);

            if(editou)
            {
                Usuario usuarioEditado = repositorio.BuscarPorId(id);

                Console.WriteLine($"Confira seu novo cadastro {usuarioEditado}");
            }
            else
            {
                Console.WriteLine("Erro");
            }


        }

        private static void Excluir()
        {
            Console.Clear();

            Console.WriteLine("Informe o id para excluir");
            int id = Convert.ToInt32(Console.ReadLine()!);

            bool excluiu = repositorio.Excluir(id);

            if(excluiu)
            {
                Console.WriteLine("Usuario removido com sucesso\nTecle para continuar...");
                Console.ReadKey();
            }
        }

        private static void VerTodos()
        {
            Console.Clear();

            foreach (var item in repositorio.BuscarTodos())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static void Logar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu login");
            string login = Console.ReadLine()!;

            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine()!;

            Usuario usuario = new Usuario(login, senha);

            Usuario usuarioBuscado = repositorio.BuscarUsuario(usuario);

            if(usuarioBuscado == null)
            {
                Console.WriteLine("Usuario não Cadastrado, deseja se cadastrar ?\nSim [1]\nNão [2]");
                var opcao = Console.ReadLine();

                if(opcao == "1")
                {
                    Cadastrar();
                }
                else if(opcao == "2")
                {
                    return;
                }
            }
            else
            {
                Acessar(usuarioBuscado);
            }

        }

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu login");
            string login = Console.ReadLine()!;

            Console.WriteLine("Digite sua senha");
            string senha = Console.ReadLine()!;

            Usuario usuario = new Usuario(login, senha);

            bool cadastrou = repositorio.Cadastrar(usuario);

            if(cadastrou == false)
            {
                Console.WriteLine("algo deu errado");
            }
            else
            {
                Acessar(usuario);
            }
        }

        private static void Acessar(Usuario usuarioLogado)
        {
            Menu(usuarioLogado);
        }

        private static void Menu(Usuario usuario)
        {
           while (true)
            {
                Console.Clear();
                Console.WriteLine($"Usuário logado: {usuario}");
                Console.WriteLine("Digite 1 Contatos");
                Console.WriteLine("Digite 2 Produtos");
                Console.WriteLine("Digite 3 Vendas");
                Console.WriteLine("Digite 4 Sair");

                string opcao = Console.ReadLine()!;

                SubMenu subMenu = null!;

                if (opcao == "1")
                {
                    subMenu = new MenuContato();
                }
                else if (opcao == "2")
                {
                    subMenu = new MenuProduto();
                }
                else if (opcao == "3")
                {
                    return;
                }
                else
                {
                    return;
                }

                subMenu.MostrarMenu();
            }

        }
    }
}