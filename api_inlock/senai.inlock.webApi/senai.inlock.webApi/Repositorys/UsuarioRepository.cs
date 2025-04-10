using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // String de conexão com o banco de dados que recebe os seguintes parâmetros:
        //Data Source: Nome do servidor
        //Initial Catalog: Nome do banco de dados
        //Autenticação:
        //             -Windows : Integrated Security = true
        //             -SqlServer : User Id = sa; Pwd = Senha
        private string StringConexao = "Data Source = NOTE02-S15; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Método que cadastra objeto(Usuario)
        /// </summary>
        /// <param name="novoUsuario">objeto(Usuario) que será cadastrado</param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryInsert = "INSERT INTO Usuario(IdTipoUsuario, Email, Senha) VALUES(@IdTipoUsuario, @Email, @Senha)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryLogin = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        UsuarioDomain user = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
                        };

                        return user;
                    }
                    return null;
                }
            }
        }
    }
}
