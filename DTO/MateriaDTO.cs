namespace UnivalGeovanni.DTO
{
    public class MateriaDTO
    {
        
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public ProfessorDTO Professor { get; set; }
            public List<MateriaDTO>?Dependencias { get; set; }
        
    }
}
