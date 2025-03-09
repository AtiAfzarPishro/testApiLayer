using Microsoft.EntityFrameworkCore;
using Test.API.sample.Models.DomainModels;

namespace Test.API.sample.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) 
            {

            }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
