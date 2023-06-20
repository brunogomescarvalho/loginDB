using Dominio;
using System.Data.SqlClient;


namespace InfraData.DAO
{
    public class DaoUsuario
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pagina_login;Integrated Security=True;";


        public bool Cadastrar(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string insert = @"insert into Usuario (USUARIO,SENHA) VALUES 
                    (@USUARIO,@SENHA)";
                  
                    command.Parameters.AddWithValue("@USUARIO", usuario.NomeUsuario);
                    command.Parameters.AddWithValue("@SENHA", usuario.Senha);

                    command.CommandText = insert;

                   int linhasAfetadas = command.ExecuteNonQuery();

                    return linhasAfetadas > 0;
                }
            }
        }

        public List<Usuario> BuscarTodos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT * FROM USUARIO";

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    List<Usuario> usuarios = new List<Usuario>();

                    while(reader.Read())
                    {
                        int id = int.Parse(reader["ID"].ToString()!);
                        string nome = reader["USUARIO"].ToString()!;
                        string senha = reader["SENHA"].ToString()!;

                        Usuario usuario = new Usuario(id, nome, senha);

                        usuarios.Add(usuario);
                    }

                    return usuarios;
                }
            }
        }

        public bool Excluir(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string delete = @"DELETE FROM USUARIO WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID",id);

                    command.CommandText = delete;

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT * FROM USUARIO WHERE ID = @ID";

                   
                    command.Parameters.AddWithValue("@ID", id);

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int Id = int.Parse(reader["ID"].ToString()!);
                        string nome = reader["USUARIO"].ToString()!;
                        string senha = reader["SENHA"].ToString()!;

                        return new Usuario(id, nome, senha);


                    }

                    return null!;
                }
            }

        }

        public Usuario BuscarUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string select = @"SELECT * FROM USUARIO WHERE USUARIO = @USUARIO AND SENHA = @SENHA";

                    command.Parameters.AddWithValue("@USUARIO", usuario.NomeUsuario);
                    command.Parameters.AddWithValue("@SENHA", usuario.Senha);

                    command.CommandText = select;

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        int id = int.Parse(reader["ID"].ToString()!);
                        string nome = reader["USUARIO"].ToString()!;
                        string senha = reader["SENHA"].ToString()!;

                       return new Usuario(id, nome, senha);


                    }

                    return null!;
                }
            }
        }

        public bool Editar(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    string upDate = @"update USUARIO SET USUARIO = @USUARIO, SENHA = @SENHA WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", usuario.Id);
                    command.Parameters.AddWithValue("@USUARIO", usuario.NomeUsuario);
                    command.Parameters.AddWithValue("@SENHA", usuario.Senha);

                    command.CommandText = upDate;

                    return command.ExecuteNonQuery()>0;

                }
            }
        }


        }
    }
