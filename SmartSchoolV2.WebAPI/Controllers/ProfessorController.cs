using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolV2.WebAPI.Data;
using SmartSchoolV2.WebAPI.Models;

namespace SmartSchoolV2.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        
       private readonly SmartContext _context;

        public ProfessorController(SmartContext context){ 
            _context = context;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
                return BadRequest("O Professor não foi encontrado.");

            return Ok(aluno);
        }

        
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {

            var aluno = _context.Professores.FirstOrDefault(a => 
                a.Nome.Contains(nome) );

            if (aluno == null)
                return BadRequest("O Professor não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor não encontrado");

            _context.Professores.Update(professor);
            _context.SaveChanges();
            
            return Ok("Processor alterado com sucesso");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var alu = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor não encontrado");


            _context.Professores.Update(professor);
            _context.SaveChanges();
            
            return Ok("Professor alterado com sucesso");
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (professor == null)
                return BadRequest("Professor não encontrado");
            
             _context.Professores.Remove(professor);
            _context.SaveChanges();
            
            return Ok("Professor alterado com sucesso");
        }
        
    }
}