using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;
using WebApplication2.NewFolder;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonneController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getAllUser()
        {
            var heroes = await _context.Personees.ToListAsync();
            return Ok(heroes);
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personee>> getSpecificHero(int id)
        {
            var heroes = await _context.Personees.FindAsync(id);
            if(heroes is null)
            { 
                return NotFound("Hero not found");
            }
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<Personee>>>addPersonne(Personee newPersonne)
        {
            _context.Personees.Add(newPersonne);
            await  _context.SaveChangesAsync();
            return Ok(await _context.Personees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Personee>>>updatePersonne(Personee newPersonee)
        {
            var _oldPersonee = await _context.Personees.FindAsync(newPersonee.Id);
            if(_oldPersonee ==null)
                return NotFound("user not found with this data"); 
            
            
            _oldPersonee.Name = newPersonee.Name;
            _oldPersonee.LastName= newPersonee.LastName;
            _oldPersonee.Place=newPersonee.Place;
            _oldPersonee.FirstName=newPersonee.FirstName;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Personees.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Personee>>>deletePersonne(int id)
        {
            var _personne = await _context.Personees.FindAsync(id);
            if (_personne == null)
                return NotFound("User not found with this id please try to correct him");
            _context.Personees.Remove(_personne);
           await  _context.SaveChangesAsync();
            return Ok(await _context.Personees.ToListAsync());
        }
    }
}
