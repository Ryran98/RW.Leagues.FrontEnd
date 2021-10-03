using System.Collections.Generic;
using RW.Leagues.FrontEnd.Models;

namespace RW.Leagues.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RW.Leagues.FrontEnd.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext db)
        {
            List<Country> countries = _Countries();
            countries.ForEach(c => db.Countries.AddOrUpdate(c));

            List<Player> players = _Players(db);
            players.ForEach(p => db.Players.AddOrUpdate(p));

            List<EventType> eventTypes = _EventTypes();
            eventTypes.ForEach(t => db.EventTypes.AddOrUpdate(t));

            List<Event> events = _Events();
            events.ForEach(e => db.Events.AddOrUpdate(e));

            db.SaveChanges();
        }

        private List<Country> _Countries()
        {
            List<Country> countries = new List<Country>
            {
                new Country
                {
                    Id = 1,
                    Name = "England"
                }
            };

            return countries;
        }

        private List<Player> _Players(ApplicationDbContext db)
        {
            Country country = db.Countries.FirstOrDefault(c => c.Id == 1);

            List<Player> players = new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Ryan",
                    LastName = "Wilson",
                    DateOfBirth = new DateTime(1998, 01, 05),
                    Country = country,
                    CountryId = 1
                }
            };

            return players;
        }

        private List<EventType> _EventTypes()
        {
            List<EventType> eventTypes = new List<EventType>
            {
                new EventType
                {
                    Id = 1,
                    Name = "BRONZE",
                    BasePointsPerRound = 2
                },
                new EventType
                {
                    Id = 2,
                    Name = "SILVER",
                    BasePointsPerRound = 4
                },
                new EventType
                {
                    Id = 3,
                    Name = "GOLD",
                    BasePointsPerRound = 8
                },
                new EventType
                {
                    Id = 4,
                    Name = "PLATINUM",
                    BasePointsPerRound = 16
                }
            };

            return eventTypes;
        }

        private List<Event> _Events()
        {
            List<Event> events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Name = "Chinese Open",
                    TypeId = 1
                }
            };
            return events;
        }
    }
}
