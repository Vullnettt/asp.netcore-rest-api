using asp.netcore_rest_api.Dtos;
using asp.netcore_rest_api.Models;
using asp.netcore_rest_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace asp.netcore_rest_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost("addPerson")]
        public async Task<ActionResult<List<Person>>> AddPerson(CreatePersonDto createPerson)
        {
            return Ok(await personRepository.AddPerson(createPerson));
        }

        [HttpGet("getPersonById/{id}")]
        public async Task<ActionResult<Person>> GetPersonById(Guid id)
        {
            return Ok(await personRepository.GetPersonById(id));
        }

        [HttpGet("getPersons")]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return Ok(await personRepository.GetPersons());
        }

        [HttpDelete("deletePersonById/{id}")]
        public async Task<ActionResult<List<Person>>> DeletePersonById(Guid id)
        {
            return Ok(await personRepository.DeletePersonById(id));
        }

        [HttpPut("updatePerson")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(UpdatePersonDto person)
        {
            return Ok(await personRepository.UpdatePerson(person));
        }
    }
}
