using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMinimalDb.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(SamuraiContext context)
        {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Samurais.Any())
                {
                    return;   // DB has been seeded
                }

            var samurais = new Samurai[]
            {
                        new Samurai {Name =  "Luke",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        }

            };

            foreach(Samurai samurai in samurais)
            {
                context.Samurais.Add(samurai);
            }
            context.SaveChanges();
        }
    }
}
