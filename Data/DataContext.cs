using Microsoft.EntityFrameworkCore;
using web_api.models;

namespace web_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        

        // to query and set characters
        public DbSet<Character> Characters => Set<Character>();

        public DbSet<User> Users => Set<User>();
    }
}