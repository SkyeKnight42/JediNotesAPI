//using Microsoft.EntityFrameworkCore;
using JediAPI.Models;
using JediAPI.Data;

namespace JediAPI
{
    public class Seed
    {
        private readonly JediAPIDbContext dataContext;
        public Seed(JediAPIDbContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            if (dataContext.JediNotes.Any())
            {
                var JediNotes = new List<JediNote>()
                {
                    new JediNote()
                    {
                        //Id = new Guid().ToString(),
                        Title = "The chosen one is found!",
                        Body = "The entire plot of Star Wars: Episode I - The Phantom Menace",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "George Lucas",
                        JediRank = "Master"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Pod Racing is Awesome",
                        Body = "Pod racing is cool and young Anakin Skywalker wins the race.",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "Pod Racing Commentators",
                        JediRank = "Padawan"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Qui-Gon Jinn is killed by Darth Maul",
                        Body = "Qui-gon Jinn is stabbed by Darth Maul.",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "Obi-Wan Kenobi",
                        JediRank = "Padawan"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Anakin Skywalker rides some weird thing in a field of flowers",
                        Body = "Exactly what the title says. It's a weird scene.",
                        Owner = "Bad writers",
                        JediRank = "Padawan",
                        Created = DateTime.Now,
                        Updated = DateTime.Now
                    }, new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Count Doku vs Yoda",
                        Body = "Best scene in Star Wars: Episode II - The Clone Wars",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "Skye Breeze",
                        JediRank = "Master"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Space battle above Coruscant",
                        Body = "The opening scene in Star Wars: Episode III - Revenge of the Sith",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "George Lucas",
                        JediRank = "Master"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "Anakin Skywalker wants to be a jedi master",
                        Body = "Anakin has too much anger and not enough experience to be a jedi master",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "Anakin Skywalker",
                        JediRank = "Knight"
                    },
                    new JediNote()
                    {
                        //Id = new Guid(),
                        Title = "The Knights of Ren",
                        Body = "This is here to add more jedi ranks with the value Knight. Also these guys ended up being a disappointment.",
                        Created = DateTime.Now,
                        Updated = DateTime.Now,
                        Owner = "Skye Breeze",
                        JediRank = "Knight"
                    }
                };
                dataContext.JediNotes.AddRange(JediNotes);
                dataContext.SaveChanges();
            }
        }
    }
}
