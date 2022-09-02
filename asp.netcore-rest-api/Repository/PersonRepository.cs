using asp.netcore_rest_api.Data;
using asp.netcore_rest_api.Dtos;
using asp.netcore_rest_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.netcore_rest_api.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext personDb;
        private readonly IMapper mapper;

        public PersonRepository(PersonDbContext personDb, IMapper mapper)
        {
            this.personDb = personDb;
            this.mapper = mapper;
        }

        public async Task<ActionResult<List<Person>>> AddPerson(CreatePersonDto createPerson)
        {
            personDb.people.Add(mapper.Map<Person>(createPerson));
            await personDb.SaveChangesAsync();
            return await personDb.people.ToListAsync();
        }

        public async Task<ActionResult<List<Person>>> DeletePersonById(Guid id)
        {
            var person = await personDb.people.FindAsync(id);
            personDb.people.Remove(person);
            await personDb.SaveChangesAsync();
            return await personDb.people.ToListAsync();
        }

        public async Task<ActionResult<Person>> GetPersonById(Guid id)
        {
            return await personDb.people.FindAsync(id);
        }

        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return await personDb.people.ToListAsync();
        }

        public async Task<ActionResult<List<Person>>> UpdatePerson(UpdatePersonDto person)
        {
            mapper.Map<Person>(person);
            var persons = await personDb.people.FindAsync(person.Id);
            persons.FirstName = person.FirstName;
            persons.LastName = person.LastName;
            persons.Age = person.Age;
            persons.Email = person.Email;
            persons.Password = person.Password;
            persons.Address = person.Address;

            await personDb.SaveChangesAsync();
            return await personDb.people.ToListAsync();
        }
    }
}
