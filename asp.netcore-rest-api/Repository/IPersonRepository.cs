using asp.netcore_rest_api.Dtos;
using asp.netcore_rest_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.netcore_rest_api.Repository
{
    public interface IPersonRepository
    {
        public Task<ActionResult<List<Person>>> AddPerson(CreatePersonDto createPerson);
        public Task<ActionResult<List<Person>>> GetPersons();
        public Task<ActionResult<Person>> GetPersonById(Guid id);
        public Task<ActionResult<List<Person>>> UpdatePerson(UpdatePersonDto person);
        public Task<ActionResult<List<Person>>> DeletePersonById(Guid id);
    }
}
