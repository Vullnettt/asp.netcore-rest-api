using asp.netcore_rest_api.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.netcore_rest_api.Data
{
    public class PersonDbContext : DbContext
    { 
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }
        public DbSet<Person> people { get; set; }
    }
}
