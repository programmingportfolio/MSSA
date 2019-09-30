using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMinimalDb.Models
{
    public static class OverwriteDb
    {
        public static void EnsurePopulated3(SamuraiContext context)
        {
            //context.Database.EnsureDeleted();

            var existingSamurais = context.Samurais;
            var newSamurais = new Samurai[]
           {
                        new Samurai {Name =  "Luke",
                        Id = 100,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke2",
                        Id = 100,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke3",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke11",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        }

           };

            // Look for existing matches

            var union = existingSamurais.Union(newSamurais);
            List<Samurai> unionList = union.Select(s => new Samurai { Name = s.Name, Quotes = s.Quotes }).ToList();
            foreach (Samurai samurai in unionList)
            {

                context.Samurais.Add(samurai);
            }
            context.SaveChanges();
            //context.Database.CommitTransaction();
        }

        public static void EnsurePopulated(SamuraiContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var existingSamurais = context.Samurais.ToList();
            var newSamurais = new Samurai[]
           {
                        new Samurai {Name =  "Luke",
                        Id = 5,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke2",
                        Id = 2,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke3",
                        Id = 3,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke4",
                        Id = 4,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke5",
                        Id = 13,
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        }

           };

            // Look for existing matches

            var diff = from samurai in newSamurais
                       where !existingSamurais.Any(s => s.Id == samurai.Id)
                       select samurai;

            List<Samurai> diffList = diff.Select(s => new Samurai { Name = s.Name, Quotes = s.Quotes}).ToList();
            foreach (Samurai samurai in diffList)
            {
                context.Samurais.Add(samurai);
            }

            context.SaveChanges();
        }

        public static void EnsurePopulated2(SamuraiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var existingSamurais = context.Samurais.ToList();
            var newSamurais = new Samurai[]
           {
                        new Samurai {Name =  "Luke",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke2",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke3",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke4",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        }

           };

            // Look for existing matches
            if (context.Samurais.Any())
            {
                for (int i = 0; i < newSamurais.Length; i++)
                {
                    if (existingSamurais.Contains(newSamurais[i]))
                    {
                        Console.WriteLine("Match found");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"New Entry {newSamurais[i].Name}");
                        existingSamurais.Add(newSamurais[i]);
                    }
                }
                context.SaveChanges();
                return;   // DB has been seeded
            }
            else
            {
                foreach (Samurai samurai in newSamurais)
                {
                    context.Samurais.Add(samurai);
                }
                context.SaveChanges();
                return;
            }
        }
    }
    public static class NewDb
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
                        },
                        new Samurai {Name =  "Luke2",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        },
                        new Samurai {Name =  "Luke3",
                        Quotes = new List<Quote>
                        {
                            new Quote {Text = "Amazing"}
                        }
                        }

            };

            foreach (Samurai samurai in samurais)
            {
                context.Samurais.Add(samurai);
            }
            context.SaveChanges();
        }
    }
}