using SoftwareStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var existingSoftware = context.Softwares.ToList();
            var newSoftware = new Software[0];
            /*
            var newSoftware = new Software[]
           {
                        new  {Name =  "Luke",
                        Id = 5
                        }

           };
           */

            // Look for existing matches

            var diff = from software in newSoftware
                       where !existingSoftware.Any(s => s.ProductName == software.ProductName)
                       select software;

           /* List<Software> diffList = diff.Select(s => new Software { UserName = s.Name, Quotes = s.Quotes 
            
            }).ToList();
            foreach (Software software in diffList)
            {
                context.Softwares.Add(software);
            }

            context.SaveChanges();
            */
        }
    }
}
