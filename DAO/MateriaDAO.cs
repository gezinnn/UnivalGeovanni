 using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.DAO
{
    public class MateriaDAO
    {
        public void CadastrarMateria(MateriaDTO materia)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"INSERT INTO Materias (Nome, Descricao, Professor)
                            VALUES (@nome, @descricao, @professor);
                            SELECT LAST_INSERT_ID();";

                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@nome", materia.Nome);
                comando.Parameters.AddWithValue("@descricao", materia.Descricao);
                comando.Parameters.AddWithValue("@professor", materia.Professor.Id);
                

                int idMateria = Convert.ToInt32(comando.ExecuteScalar());

                if (materia.Dependencias is null) return;

                foreach (var dependencia in materia.Dependencias)
                {
                    CadastrarDependencia(idMateria, dependencia.ID);
                }     
              //  comando.ExecuteNonQuery();
            //    conexao.Close();
            }
        }

        public void CadastrarDependencia(int materia, int dependencia)
        {
            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = @"INSERT INTO DependenciasMaterias (Materia, Dependencia)
                            VALUES (@materia, @dependencia)";

                var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@materia", materia);
                comando.Parameters.AddWithValue("@dependencia", dependencia);
                comando.ExecuteNonQuery();
            }
        }

        public List<MateriaDTO> ListarMateria()
        {
            var materia = new List<MateriaDTO>();

            using (var conexao = ConnectionFactory.Build())
            {
                conexao.Open();

                var query = "SELECT * FROM Materias";

                var comando = new MySqlCommand(query, conexao);
                var dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    var Materia = new MateriaDTO
                    {
                        ID = int.Parse(dataReader["ID"].ToString()),
                        Nome = dataReader["Nome"].ToString(),
                        Descricao = dataReader["Descricao"].ToString(),
                        Professor = new ProfessorDTO { Id = int.Parse(dataReader["Professor"].ToString()) }
                    };
                    materia.Add(Materia);
                }
            }

            return materia;
        }
    }
}
/