using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace senai.inlock.webApi_.Repositorys
{
    public class JogoRepository : IJogoRepository
    {
        // String de conexão com o banco de dados que recebe os seguintes parâmetros:
        //Data Source: Nome do servidor
        //Initial Catalog: Nome do banco de dados
        //Autenticação:
        //             -Windows : Integrated Security = true
        //             -SqlServer : User Id = sa; Pwd = Senha
        private string StringConexao = "Data Source = NOTE02-S15; Initial Catalog = inlock_games_manha; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Método que cadastra objeto(jogo)
        /// </summary>
        /// <param name="novoJogo">Objeto(jogo) que será cadastrado</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(Nome, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    cmd.ExecuteNonQuery();

                }
            }
        }


        /// <summary>
        /// Método que deleta objeto(jogo) pelo ID
        /// </summary>
        /// <param name="id">ID do objeto que será deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método que lista todos os objetos(jogos)
        /// </summary>
        /// <returns>Lista de objetos(jogos)</returns>
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> ListaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Estudio.IdEstudio, Jogo.Nome, DataLancamento, Valor, Descricao, Estudio.Nome FROM Jogo JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr= cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = Convert.ToString(rdr["Nome"]),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr["Valor"]),
                            Descricao = Convert.ToString(rdr["Descricao"]),

                            Estudio = new EstudioDomain()
                            {
                                Nome = Convert.ToString(rdr["Nome"]),
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            }

                        };

                        ListaJogo.Add(jogoBuscado);
                    }
                }
                return ListaJogo;
            }
        }
    }
}
