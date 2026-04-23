using LojaEcomerce.Models;
using MySql.Data.MySqlClient;

namespace LojaEcomerce.Repositorio
{
    public class UsuarioRepositorio
    {
        //variavel privada somente leitura
        //receber a conexão do banco de dados
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }
        // metodo para validar o login
        public LoginViewModel validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
        }
    }
}
