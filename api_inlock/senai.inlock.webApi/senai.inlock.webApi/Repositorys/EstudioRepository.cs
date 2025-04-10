using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositorys
{
    public class EstudioRepository : IEstudioRepository
    {
        // String de conexão com o banco de dados que recebe os seguintes parâmetros:
        //Data Source: Nome do servidor
        //Initial Catalog: Nome do banco de dados
        //Autenticação:
        //             -Windows : Integrated Security = true
        //             -SqlServer : User Id = sa; Pwd = Senha
        private string StringConexao = "Data Source = NOTE02-S15; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Método que cadastra novo estudio
        /// </summary>
        /// <param name="novoEstudio">estudio que sera cadastrado</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para deletar estudio
        /// </summary>
        /// <param name="id">id do estudio que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método que lista estudio
        /// </summary>
        /// <returns>retorna uma lista de estudio</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> ListarEstudio = new List<EstudioDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelect = "SELECT IdEstudio, Nome FROM Estudio";

                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelect,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = Convert.ToString(rdr["Nome"])
                        };

                        ListarEstudio.Add(estudioBuscado);
                    }
                }

                return ListarEstudio;
            }
        }
    }
}
