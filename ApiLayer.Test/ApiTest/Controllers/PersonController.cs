using Microsoft.AspNetCore.Mvc;
using Test.API.sample.Models;
using Test.API.sample.Models.DomainModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test.API.sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        #region [- Ctor -]
        public PersonController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

        #region [- GetAll() -]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return await _dbContext.People.ToListAsync();
        }
        #endregion

        #region [- GetById() -]
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await _dbContext.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        #endregion

        #region [- Post() -]
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }
        #endregion

        #region [- Put() -]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPerson(Guid id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(person).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return NoContent();
        }
        #endregion

        #region [- Delete() -]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var person = await _dbContext.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();


            return NoContent();
        } 
        #endregion
    }
}
