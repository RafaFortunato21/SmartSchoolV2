using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SmartSchoolV2.WebAPI.Data;
using SmartSchoolV2.WebAPI.Models;

namespace SmartSchoolV2.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context){ 
            _context = context;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado.");

            return Ok(aluno);
        }

        
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {

            var aluno = _context.Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.SobreNome.Contains(sobrenome)
            );

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            
            return Ok("Aluno alterado com sucesso");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");


            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            
            return Ok("Aluno alterado com sucesso");
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return BadRequest("Aluno não encontrado");
            
             _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            
            return Ok("Aluno alterado com sucesso");
        }
        
    }
}