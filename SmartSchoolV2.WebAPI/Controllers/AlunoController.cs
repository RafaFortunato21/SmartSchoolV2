using Microsoft.AspNetCore.Mvc;
using SmartSchoolV2.WebAPI.Models;

namespace SmartSchoolV2.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marta",
                SobreNome = "Almeida",
                Telefone = "21 96562-5458"
            },

            new Aluno(){
                Id = 2,
                Nome = "Rafa",
                SobreNome = "Kent",
                Telefone = "21 96562-5458"
            },

            new Aluno(){
                Id = 3, 
                Nome = "João",
                SobreNome ="Maria",
                Telefone = "21 96562-5458"
            },
        };
        
        public AlunoController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado.");

            return Ok(aluno);
        }

        
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {

            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.SobreNome.Contains(sobrenome)
            );

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            Alunos.Add(aluno);
            
            return Ok("Aluno incluido com sucesso");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        
    }
}