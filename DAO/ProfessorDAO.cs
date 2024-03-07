using MySql.Data.MySqlClient;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.DAO
{
    public class ProfessorDAO
    {
        public void CadastarProfessor(ProfessorDTO professor)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Professores (Nome, CPF, Email, Celular, DataNascimento)
                         VALUES (@nome, @cpf, @email, @celular, @datanascimento);";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", professor.Nome);
            comando.Parameters.AddWithValue("@cpf", professor.CPF);
            comando.Parameters.AddWithValue("@email", professor.Email);
            comando.Parameters.AddWithValue("@celular", professor.Celular);
            comando.Parameters.AddWithValue("@datanascimento", professor.DataNascimento);
            comando.ExecuteNonQuery();
        }
        public bool VerificarProfessor(ProfessorDTO professor)
        {
            bool professorExiste = false;
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();
                var query = "SELECT COUNT(*) FROM Professores WHERE Email = @email";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@email", professor.Email);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    professorExiste = count > 0;
                }
            }
            return professorExiste;
        }
    }
}

