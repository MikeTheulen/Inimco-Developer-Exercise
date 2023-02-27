using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backend.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();

            modelBuilder.Entity<User>()
                .Property(v => v.SocialSkills)
                .HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>());

            modelBuilder.Entity<User>()
                .Property(v => v.SocialAccounts)
                .HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<List<Socials>>(v) ?? new List<Socials>());
        }

        public DbSet<User> Users { get; set; }
    }
}
