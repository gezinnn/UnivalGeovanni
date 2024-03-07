using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnivalGeovanni.DAO;
using UnivalGeovanni.DTO;

namespace UnivalGeovanni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnivalController : ControllerBase
    {
        [HttpPost]
        [Route("CadastrarAluno")]

        public IActionResult Aluno([FromBody] AlunoDTO aluno)
        {
            var dao = new AlunoDAO();
            var alunoExiste = dao.VerificarAluno(aluno);

            if (alunoExiste)
            {
                var mensagem = "E-mail já existe na base de dados";
                return Conflict(mensagem);
            }

            dao.CadastarAluno(aluno);
            return Ok();
        }

        [HttpPost]
        [Route("CadastrarProfessor")]

        public IActionResult Professor([FromBody] ProfessorDTO professor)
        {
            var dao = new ProfessorDAO();
            var professorExiste = dao.VerificarProfessor(professor);

            if (professorExiste)
            {
                var mensagem = "E-mail já existe na base de dados";
                return Conflict(mensagem);
            }

            dao.CadastarProfessor(professor);
            return Ok();
        }

        [HttpPost]
        [Route("CadastrarMateria")]
        public IActionResult CadastrarMateria([FromBody] MateriaDTO materia)
        {
            try
            {
                var dao = new MateriaDAO();
                dao.CadastrarMateria(materia);
                return Ok("Matéria cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar matéria: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarMatricula")]

        public IActionResult Matricula()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult ListarAluno()
        {
            var dao = new AlunoDAO();

            var aluno = dao.ListarAluno();
            return Ok(aluno);
        }

        [HttpGet]
        [Route("ListarMateria")]
        public IActionResult ListarMateria()
        {
            var dao = new MateriaDAO();

            var aluno = dao.ListarMateria();
            return Ok(aluno);
        }

        [HttpGet]
        [Route("ListarProfessores")]
        public IActionResult ListarTeacherrrr()
        {
            var dao = new ProfessorDAO();

            var professor = dao.ListaTeacherrrr();
            return Ok(professor);
        }
    }
}
