namespace Dominio
{
    public class Usuario
    {
       

        public int Id { get; set; }
        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public Usuario(int id, string nomeUsuario, string senha)
        {
            Id = id;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public Usuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public override string ToString()
        {
            return $"{NomeUsuario} {Id} {Senha}";
        }
    }
}