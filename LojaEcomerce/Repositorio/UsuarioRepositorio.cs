using LojaEcomerce.Interfaces;
using LojaEcomerce.Models;
using MySql.Data.MySqlClient;

namespace LojaEcomerce.Repositorio
{
    public class UsuarioRepositorio : Iusuariorepositorio
    {
        //variavel privada somente leitura
        //receber a conexão do banco de dados
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");
        }
        // metodo para validar o login
        public LoginViewModel Validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT * FROM tb_usuario WHERE email=@email AND Senha = @senha";
            var cmd =new MySqlCommand(sql, conn);
            cmd .Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using var reader = cmd.ExecuteReader();
            if (reader.Read()) {
                return new LoginViewModel
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nome = reader["Nome"].ToString(),
                    Email = reader["email"].ToString(),
                    Nivel = reader["email"].ToString(),
                };
            }
            return null;
        }
    }
}
