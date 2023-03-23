using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<RegexLibrary> regexLibraries { get; set; }

        public DbSet<User> users { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    }
}
