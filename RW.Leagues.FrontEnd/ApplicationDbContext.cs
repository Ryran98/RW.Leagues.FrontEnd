using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public ApplicationDbContext() : base("LeagueDb") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}