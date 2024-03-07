using MySql.Data.MySqlClient;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.DAO
{
    public class MateriaDAO
    {
        public void CadastrarMateria(MateriaDTO materia)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO Materias (Nome, Descricao, Professor,)
                        VALUES (@nome, @descricao, @professor);
                        SELECT LAST_INSERT_ID();";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", materia.Nome);
            comando.Parameters.AddWithValue("@descricao", materia.Descricao);
            comando.Parameters.AddWithValue("@professor", materia.Professor);

            int idMateria = Convert.ToInt32(comando.ExecuteScalar());

            if (materia.Dependencias is null) return;

            foreach (var dependencia in materia.Dependencias)
            {
                CadastrarDependencia(idMateria, dependencia.ID);
            }
        }


        public void CadastrarDependencia(int materia, int dependencia)
        {
            var conexao = ConnectionFactory.Build();
            conexao.Open();

            var query = @"INSERT INTO DependenciasMaterias (Materia, Dependencia)
                        VALUES (@materia, @dependencia)";

            var comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@materia", materia);
            comando.Parameters.AddWithValue("@dependencias", dependencia);
            comando.ExecuteNonQuery();

        }
    }
}
