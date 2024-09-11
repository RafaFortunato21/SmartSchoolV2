using Microsoft.AspNetCore.Mvc;
using SmartSchoolV2.WebAPI.Models;

namespace SmartSchoolV2.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        

        public ProfessorController(){}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Paulo, Marco");
        }
        
    }
}