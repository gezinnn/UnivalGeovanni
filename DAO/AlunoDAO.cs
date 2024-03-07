using MySql.Data.MySqlClient;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.DAO
{
    public class AlunoDAO
    {
        public void CadastarAluno(AlunoDTO aluno)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Alunos (Nome, CPF, Email, Celular, DataNascimento)
                         VALUES (@nome, @cpf, @email, @celular, @datanascimento)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@cpf", aluno.CPF);
            comando.Parameters.AddWithValue("@email", aluno.Email);
            comando.Parameters.AddWithValue("@celular", aluno.Celular);
            comando.Parameters.AddWithValue("@datanascimento", aluno.DataNascimento);
            comando.ExecuteNonQuery();
        }

        public List<AlunoDTO> ListarAluno() 
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = "SELECT * FROM Alunos";

            var comando = new MySqlCommand(query, conexao);
            var dataReader = comando.ExecuteReader();

            var alunos = new List<AlunoDTO>(); 

            while (dataReader.Read())
            {
                var alunoDTO = new AlunoDTO();
                alunoDTO.Id = int.Parse(dataReader["ID"].ToString());
                alunoDTO.Nome = dataReader["Nome"].ToString();
                alunoDTO.CPF = dataReader["CPF"].ToString();
                alunoDTO.Email = dataReader["Email"].ToString();
                alunoDTO.Celular = dataReader["Celular"].ToString();
                alunoDTO.DataNascimento = (DateTime)dataReader["DataNascimento"];
                alunos.Add(alunoDTO); 
            }

            return alunos; 
        }

        public bool VerificarAluno(AlunoDTO aluno)
        {
            bool alunoExiste = false;
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();
                var query = "SELECT COUNT(*) FROM Alunos WHERE Email = @email";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@email", aluno.Email);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    alunoExiste = count > 0;
                }
            }
            return alunoExiste;
        }
    }
}
