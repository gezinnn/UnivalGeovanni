namespace UnivalGeovanni.DTO
{
    public class MatriculaDTO
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public AlunoDTO Aluno { get; set; }
        public MateriaDTO Materia { get; set; }
    }
}
