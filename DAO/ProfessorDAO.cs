using MySql.Data.MySqlClient;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.DAO
{
    public class ProfessorDAO
    {
        public int CadastarProfessor(ProfessorDTO professor)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Professor (Nome, CPF, Email, Celular, DataNascimento)
                         VALUES (@nome, @cpf, @email, @celular, @datanascimento)SELECT LAST_INSERT_ID();";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", professor.Nome);
            comando.Parameters.AddWithValue("@cpf", professor.CPF);
            comando.Parameters.AddWithValue("@email", professor.Email);
            comando.Parameters.AddWithValue("@celular", professor.Celular);
            comando.Parameters.AddWithValue("@datanascimento", professor.DataNascimento);

            int novoID = Convert.ToInt32(comando.ExecuteScalar());
            return novoID;
        }
    }
}
